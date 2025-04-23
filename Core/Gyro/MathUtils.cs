using System.Runtime.CompilerServices;

namespace NeonGyro.Core.Gyro;

public static class MathUtils
{
	public const float PI = (float)Math.PI;
	public const float Tau = PI * 2;
	public const float DegreesToRadians = PI / 180f;
	public const float RadiansToDegrees = 180f / PI;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Clamp(float value, float min, float max)
	{
		if (value < min) return min;
		else if (value > max) return max;
		else return value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double Exp2(double x)
	{
		return (24 + x * (24 + x * (12 + x * (4 + x)))) * 0.041666666;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float InverseLerp(float from, float to, float value)
	{
		return (value - from) / (to - from);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Lerp(float from, float to, float t)
	{
		return from + (to - from) * t;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Remap(float value, float fromA, float fromB, float toA, float toB)
	{
		float t = Clamp(InverseLerp(fromA, fromB, value), 0f, 1f);
		return Lerp(toA, toB, t);
	}
}
