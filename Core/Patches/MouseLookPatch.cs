using GyroHelpers;
using HarmonyLib;
using UnityEngine;

namespace NeonGyro.Core.Patches;

internal static class MouseLookPatch
{
	private static ResetState resetState = new();
	
	[HarmonyPatch(typeof(MouseLook), "UpdateRotation")]
	[HarmonyPrefix]
	static void UpdateRotationPrefix(
		bool playerAlive,
		MouseLook __instance,
		ref float ___rotAmountX,
		ref float ___rotAmountY,
		ref float ___rotationX,
		ref float ___rotationY,
		ref float ____accelRamp
	)
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
			float flick = Mod.ControllerManager.FlickStickDelta * MathHelper.RadiansToDegrees;
			___rotationX -= flick;
		}
		else
		{
			// traditional stick
			Vector2 look = GetLook(__instance, ref ____accelRamp);
			___rotAmountX += look.x;
			___rotAmountY += look.y;
		}

		// gyro
		var gyro = Mod.ControllerManager.GyroDelta * MathHelper.RadiansToDegrees;
		gyro *= Mod.Config.GyroSensitivity.Value;
		___rotationX -= gyro.Y;
		___rotationY += gyro.X * Mod.Config.GyroSensitivityRatio.Value;

		// vertical reset
		// neon white uses 2 MouseLook instances, one on the camera (Y axis), and one on the player (X axis)
		// we should only update our reset animation on the camera
		if (__instance.axes == MouseLook.RotationAxes.MouseY)
		{
			___rotationY += resetState.Update(___rotationY, Time.deltaTime);
		}
	}

	// reimplementation of the game's original stick processing, minus aim assist
	static Vector2 GetLook(MouseLook instance, ref float accelRamp)
	{
		GameInput gameInput = Singleton<GameInput>.Instance;
		Vector2 look = new Vector2(
			gameInput.GetAxisRaw(GameInput.GameActions.LookHorizontal),
			gameInput.GetAxisRaw(GameInput.GameActions.LookVertical)
		);

		// acceleration?
		float b = Mathf.Clamp01((look.magnitude - 0.75f) / 4f);
		accelRamp = Mathf.Min(Mathf.Lerp(accelRamp, b, Time.deltaTime * 2f), b);

		return instance.JoystickAdjustedInputArcSpeed(look) * Time.deltaTime;
	}
}
