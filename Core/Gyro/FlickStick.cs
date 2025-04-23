using System.Numerics;
using System.Runtime.CompilerServices;

namespace NeonGyro.Core.Gyro;

public class FlickStick
{
	public float FlickThreshold { get; set; } = 0.9f;
	public float FlickTime { get; set; } = 0.1f;
	public float ForwardDeadzone { get; set; } = 0f;
	public float SmoothingTime { get => smoothing.SmoothTime; set => smoothing.SmoothTime = value; }
	public float SmoothingThresholdSmooth { get => smoothing.ThresholdSmooth; set => smoothing.ThresholdSmooth = value; }
	public float SmoothingThresholdDirect { get => smoothing.ThresholdDirect; set => smoothing.ThresholdDirect = value; }

	public bool IsFlicking => flicking;

	Vector2 lastStick;
	bool flicking;
	float flickProgress = 1f;
	float flickAngle;
	float? lastStickAngle;
	TieredSmoothing1D smoothing = new(0.064f, 1.15f * MathUtils.DegreesToRadians, 2.3f * MathUtils.DegreesToRadians, 256);

	public float Update(Vector2 stick, float deltaTime)
	{
		float result = 0f;

		float lastMagnitudeSqr = lastStick.LengthSquared();
		float magnitudeSqr = stick.LengthSquared();
		float thresholdSqr = FlickThreshold * FlickThreshold;
		if (magnitudeSqr >= thresholdSqr)
		{
			float stickAngle = (float)Math.Atan2(-stick.X, -stick.Y);
			if (lastMagnitudeSqr < thresholdSqr)
			{
				// stick just crossed the threshold. initiate flick at this angle
				flicking = true;

				// apply a forward deadzone on the initial flick
				if (Math.Abs(stickAngle) >= ForwardDeadzone)
				{
					if (FlickTime > 0)
					{
						flickProgress = 0;
						flickAngle = stickAngle;
					}
					else
					{
						// no flick animation. simply increment
						result += stickAngle;
					}
				}
			}
			else
			{
				// we're still outside the threshold. calculate the angle change
				float deltaAngle = stickAngle - (lastStickAngle ?? stickAngle);
				deltaAngle = WrapDeltaAngle(deltaAngle);

				// add smoothed angle change
				result += smoothing.Apply(deltaAngle, deltaTime);
			}
			lastStickAngle = stickAngle;
		}
		else if (lastMagnitudeSqr >= thresholdSqr)
		{
			lastStickAngle = null;
			flicking = false;
			smoothing.Reset();
		}

		// update flick animation
		if (flickProgress < 1f && FlickTime > 0)
		{
			// move progress forward
			float lastFlickProgress = flickProgress;
			flickProgress = Math.Min(flickProgress + (float)(deltaTime / FlickTime), 1f);

			// apply easing (optional but looks weird without it)
			float lastT = EaseOutCubic(lastFlickProgress);
			float t = EaseOutCubic(flickProgress);
			result += (t - lastT) * flickAngle;
		}

		lastStick = stick;
		return result;
	}

	public void Reset()
	{
		lastStick = Vector2.Zero;
		flicking = false;
		flickProgress = 1f;
		flickAngle = 0f;
		lastStickAngle = null;
		smoothing.Reset();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	static float WrapDeltaAngle(float value)
	{
		value = (value + MathUtils.PI) % MathUtils.Tau;
		if (value < 0)
			value += MathUtils.Tau;
		return value - MathUtils.PI;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	static float EaseOutCubic(float t)
	{
		return 1 + --t * t * t;
	}
}
