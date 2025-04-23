using NeonGyro.Core.Gyro;
using NeonGyro.Core.Gyro.GyroSpaces;
using System.Numerics;

namespace NeonGyro.Core;

class GyroState
{
	public GyroProcessor Gyro { get; } = new();
	public FlickStick FlickStick { get; } = new();

	public float BiasCalibrationTime { get; set; }

	public event Action<Vector3>? BiasCalibrated;

	JibbGravityCalculator gravityCalculator = new();
	ulong? prevTimestamp;
	GyroSpace currentGyroSpace = GyroSpace.LocalYaw;

	public void InputGyro(Vector3 gyro, Vector3 accel, ulong timestamp)
	{
		float deltaTime = (timestamp - (prevTimestamp ?? timestamp)) / 1000000000f;
		prevTimestamp = timestamp;

		if (BiasCalibrationTime > 0)
		{
			BiasCalibrationTime -= deltaTime;
			Gyro.CalibratingBias = BiasCalibrationTime > 0;
			if (BiasCalibrationTime <= 0)
				BiasCalibrated?.Invoke(Gyro.Bias);
		}

		Vector3 gravity = Gyro.GyroSpace.RequiresGravity ? gravityCalculator.Update(gyro, accel, deltaTime) : Vector3.Zero;
		Gyro.Input(gyro, accel, gravity, deltaTime);
	}

	public Vector2 UpdateGyro(IConfig config, float deltaTime)
	{
		if (currentGyroSpace != config.GyroSpace.Value)
		{
			Gyro.GyroSpace = CreateGyroSpace(config.GyroSpace.Value);
			currentGyroSpace = config.GyroSpace.Value;
		}

		Gyro.SmoothingThresholdDirect = config.GyroSmoothingThreshold.Value * MathUtils.DegreesToRadians;
		Gyro.SmoothingThresholdSmooth = config.GyroSmoothingThreshold.Value * MathUtils.DegreesToRadians * 0.5f;
		Gyro.SmoothingTime = config.GyroSmoothingTime.Value;
		Gyro.TighteningThreshold = config.GyroTightening.Value * MathUtils.DegreesToRadians;
		Gyro.Acceleration.ThresholdSlow = config.GyroAccelerationThresholdSlow.Value * MathUtils.DegreesToRadians;
		Gyro.Acceleration.ThresholdFast = config.GyroAccelerationThresholdFast.Value * MathUtils.DegreesToRadians;
		Gyro.Acceleration.SensitivitySlow = config.GyroAccelerationSensitivitySlow.Value;
		Gyro.Acceleration.SensitivityFast = config.GyroAccelerationSensitivityFast.Value;
		return Gyro.Update(deltaTime);
	}

	public float UpdateFlickStick(IConfig config, Vector2 stick, float deltaTime)
	{
		FlickStick.FlickThreshold = config.FlickThreshold.Value;
		FlickStick.FlickTime = config.FlickTime.Value;
		FlickStick.ForwardDeadzone = config.FlickForwardDeadzone.Value * MathUtils.DegreesToRadians;
		FlickStick.SmoothingThresholdDirect = config.FlickSmoothingTreshold.Value * MathUtils.DegreesToRadians;
		FlickStick.SmoothingThresholdSmooth = config.FlickSmoothingTreshold.Value * MathUtils.DegreesToRadians * 0.5f;
		FlickStick.SmoothingTime = config.FlickSmoothingTime.Value;
		return FlickStick.Update(stick, deltaTime);
	}

	static IGyroSpace CreateGyroSpace(GyroSpace space) => space switch
	{
		GyroSpace.LocalYaw => new LocalYawGyroSpace(),
		GyroSpace.LocalRoll => new LocalRollGyroSpace(),
		GyroSpace.PlayerTurn => new PlayerTurnGyroSpace(),
		GyroSpace.PlayerLean => new PlayerLeanGyroSpace(),
		_ => new LocalYawGyroSpace(),
	};

	public void FlushGyro()
	{
		Gyro.Flush();
	}
}