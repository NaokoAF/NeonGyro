using GyroHelpers;

namespace NeonGyro.Core;

public interface IConfig
{
	IConfigEntry<bool> GyroEnabled { get; }
	IConfigEntry<float> GyroSensitivity { get; }
	IConfigEntry<float> GyroSensitivityRatio { get; }
	IConfigEntry<GyroButtonMode> GyroButtonMode { get; }
	IConfigEntry<ControllerButton> GyroButton { get; }
	IConfigEntry<ControllerButton> GyroCalibrateButton { get; }
	IConfigEntry<GyroSpace> GyroSpace { get; }
	IConfigEntry<float> GyroSmoothingThreshold { get; }
	IConfigEntry<float> GyroSmoothingTime { get; }
	IConfigEntry<float> GyroTightening { get; }
	IConfigEntry<float> GyroAccelerationThresholdSlow { get; }
	IConfigEntry<float> GyroAccelerationThresholdFast { get; }
	IConfigEntry<float> GyroAccelerationSensitivitySlow { get; }
	IConfigEntry<float> GyroAccelerationSensitivityFast { get; }
	IConfigEntry<bool> FlickStickEnabled { get; }
	IConfigEntry<float> FlickThreshold { get; }
	IConfigEntry<float> FlickTime { get; }
	IConfigEntry<FlickSnapping> FlickSnapping { get; }
	IConfigEntry<float> FlickForwardDeadzone { get; }
	IConfigEntry<float> FlickSmoothingThreshold { get; }
	IConfigEntry<float> FlickSmoothingTime { get; }
}