using GyroHelpers;
using GyroHelpers.Gravity;
using GyroHelpers.GyroSpaces;
using System.Numerics;

namespace NeonGyro.Core;

public class GyroState
{
	public GyroInput GyroInput { get; } = new();
	public GyroProcessor GyroProcessor { get; } = new();
	public FlickStick FlickStick { get; } = new();

	public float BiasCalibrationTime { get; set; }

	public event Action<Vector3>? BiasCalibrated;

	GyroSpace currentGyroSpace = GyroSpace.LocalYaw;

	public Vector2 UpdateGyro(IConfig config, float deltaTime)
	{
		if (BiasCalibrationTime > 0)
		{
			BiasCalibrationTime -= deltaTime;
			GyroInput.Calibrating = BiasCalibrationTime > 0;
			if (BiasCalibrationTime <= 0)
				BiasCalibrated?.Invoke(GyroInput.Bias);
		}

		if (currentGyroSpace != config.GyroSpace.Value)
		{
			GyroProcessor.GyroSpace = CreateGyroSpace(config.GyroSpace.Value);
			currentGyroSpace = config.GyroSpace.Value;
		}

		GyroProcessor.SmoothingThresholdDirect = config.GyroSmoothingThreshold.Value * MathHelper.DegreesToRadians;
		GyroProcessor.SmoothingThresholdSmooth = config.GyroSmoothingThreshold.Value * MathHelper.DegreesToRadians * 0.5f;
		GyroProcessor.SmoothingTime = config.GyroSmoothingTime.Value;
		GyroProcessor.TighteningThreshold = config.GyroTightening.Value * MathHelper.DegreesToRadians;
		GyroProcessor.Acceleration.ThresholdSlow = config.GyroAccelerationThresholdSlow.Value * MathHelper.DegreesToRadians;
		GyroProcessor.Acceleration.ThresholdFast = config.GyroAccelerationThresholdFast.Value * MathHelper.DegreesToRadians;
		GyroProcessor.Acceleration.SensitivitySlow = config.GyroAccelerationSensitivitySlow.Value;
		GyroProcessor.Acceleration.SensitivityFast = config.GyroAccelerationSensitivityFast.Value;
		return GyroProcessor.Update(GyroInput.Gyro, deltaTime);
	}

	public float UpdateFlickStick(IConfig config, Vector2 stick, float deltaTime)
	{
		FlickStick.FlickThreshold = config.FlickThreshold.Value;
		FlickStick.FlickTime = config.FlickTime.Value;
		FlickStick.Snapping = FlickSnapping.ForwardOnly;
		FlickStick.SnappingStrength = 1f;
		FlickStick.SnappingForwardDeadzone = config.FlickForwardDeadzone.Value * MathHelper.DegreesToRadians;
		FlickStick.SmoothingThresholdDirect = config.FlickSmoothingThreshold.Value * MathHelper.DegreesToRadians;
		FlickStick.SmoothingThresholdSmooth = config.FlickSmoothingThreshold.Value * MathHelper.DegreesToRadians * 0.5f;
		FlickStick.SmoothingTime = config.FlickSmoothingTime.Value;
		return FlickStick.Update(stick, deltaTime);
	}

	static IGyroSpace CreateGyroSpace(GyroSpace space) => space switch
	{
		GyroSpace.LocalYaw => new LocalGyroSpace(),
		GyroSpace.LocalRoll => new LocalGyroSpace(GyroAxis.Pitch, GyroAxis.Roll),
		GyroSpace.PlayerTurn => new PlayerTurnGyroSpace(),
		GyroSpace.PlayerLean => new PlayerLeanGyroSpace(),
		_ => new LocalGyroSpace(),
	};

	public void Reset()
	{
		GyroProcessor.Reset();
	}
}