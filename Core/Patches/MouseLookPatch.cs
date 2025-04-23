using HarmonyLib;
using NeonGyro.Core.Gyro;
using UnityEngine;

namespace NeonGyro.Core.Patches;

[HarmonyPatch(typeof(MouseLook))]
internal static class MouseLookPatch
{
	[HarmonyPatch("UpdateRotation")]
	[HarmonyPrefix]
	static void UpdateRotationPrefix(MouseLook __instance, bool playerAlive, ref float ___rotAmountX, ref float ___rotAmountY, ref float ____accelRamp)
	{
		if (Mod.ControllerManager == null || Mod.Config == null) return; // mod not initialized
		if (!Mod.Config.GyroEnabled.Value) return; // mod disabled
		if (!Singleton<GameInput>.Instance.IsUsingGamepad()) return; // not a controller
		if (Mod.ControllerManager.ActiveController == null || !Mod.ControllerManager.ActiveController.HasGyro) return; // controller has no gyro

		if (!playerAlive || Time.timeScale <= 0.1f) return; // input disabled

		// undo joystick input
		___rotAmountX = 0f;
		___rotAmountY = 0f;

		if (Mod.Config.FlickStickEnabled.Value)
		{
			float flick = Mod.ControllerManager.FlickStickDelta * MathUtils.RadiansToDegrees;
			___rotAmountX -= flick;
		}
		else
		{
			Vector2 look = GetLook(__instance, ref ____accelRamp);
			___rotAmountX += look.x;
			___rotAmountY += look.y;
		}

		// gyro
		var gyro = Mod.ControllerManager.GyroDelta * MathUtils.RadiansToDegrees;
		gyro *= Mod.Config.GyroSensitivity.Value;

		___rotAmountX -= gyro.Y;
		___rotAmountY += gyro.X * Mod.Config.GyroSensitivityRatio.Value;
	}

	static Vector2 GetLook(MouseLook instance, ref float accelRamp)
	{
		var gameInput = Singleton<GameInput>.Instance;
		Vector2 look = new Vector2(gameInput.GetAxisRaw(GameInput.GameActions.LookHorizontal), gameInput.GetAxisRaw(GameInput.GameActions.LookVertical));

		// acceleration?
		float b = Mathf.Clamp01((look.magnitude - 0.75f) / 4f);
		accelRamp = Mathf.Min(Mathf.Lerp(accelRamp, b, Time.deltaTime * 2f), b);

		return instance.JoystickAdjustedInputArcSpeed(look) * Time.deltaTime;
	}
}
