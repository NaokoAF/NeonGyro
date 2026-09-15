using System.Runtime.CompilerServices;

namespace NeonGyro.Core;

internal class ResetState
{
	private float resetAngle;
	private float resetT; // inverted progress from 0 to 1. finished when reaching 0 
	private float prevResetAngle;
	private bool prevButtonDown;
	
	public float Update(float angle, float deltaTime)
	{
		if (Mod.ControllerManager == null || Mod.Config == null) return 0f;
		if (Mod.Config.ResetButtonMode.Value == ResetButtonMode.Disabled) return 0f;

		// activate
		bool buttonDown = Mod.ControllerManager.ResetButtonDown;
		if (buttonDown && !prevButtonDown)
		{
			resetAngle = -angle;
			resetT = 1f;
			prevResetAngle = 0f;
		}
		prevButtonDown = buttonDown;

		if (resetT <= 0f) return 0f;
		
		// animate
		resetT -= deltaTime / Mod.Config.ResetTime.Value;
		resetT = Math.Max(resetT, 0f);

		float newAngle = resetAngle * EaseOutCubic(1f - resetT);
		float angleDelta = newAngle - prevResetAngle;
		prevResetAngle = newAngle;
		return angleDelta;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static float EaseOutCubic(float t)
	{
		t -= 1f;
		return 1 + t * t * t;
	}
}