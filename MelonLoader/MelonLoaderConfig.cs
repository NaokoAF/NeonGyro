using GyroHelpers;
using MelonLoader;
using NeonGyro.Core;

namespace NeonGyro.MelonLoader;

public class MelonLoaderConfig : IConfig
{
	public IConfigEntry<bool> GyroEnabled { get; }
	public IConfigEntry<float> GyroSensitivity { get; }
	public IConfigEntry<float> GyroSensitivityRatio { get; }
	public IConfigEntry<GyroButtonMode> GyroButtonMode { get; }
	public IConfigEntry<ControllerButton> GyroButton { get; }
	public IConfigEntry<ControllerButton> GyroCalibrateButton { get; }
	public IConfigEntry<GyroSpace> GyroSpace { get; }
	public IConfigEntry<float> GyroSmoothingThreshold { get; }
	public IConfigEntry<float> GyroSmoothingTime { get; }
	public IConfigEntry<float> GyroTightening { get; }
	public IConfigEntry<float> GyroAccelerationThresholdSlow { get; }
	public IConfigEntry<float> GyroAccelerationThresholdFast { get; }
	public IConfigEntry<float> GyroAccelerationSensitivitySlow { get; }
	public IConfigEntry<float> GyroAccelerationSensitivityFast { get; }

	public IConfigEntry<bool> FlickStickEnabled { get; }
	public IConfigEntry<float> FlickThreshold { get; }
	public IConfigEntry<float> FlickTime { get; }
	public IConfigEntry<FlickSnapping> FlickSnapping { get; }
	public IConfigEntry<float> FlickForwardDeadzone { get; }
	public IConfigEntry<float> FlickSmoothingThreshold { get; }
	public IConfigEntry<float> FlickSmoothingTime { get; }

	MelonPreferences_Category category;

	internal MelonLoaderConfig()
	{
		category = MelonPreferences.CreateCategory(ModInfo.Name);

		GyroEnabled = CreateEntry(nameof(GyroEnabled), true);
		GyroSensitivity = CreateEntry(nameof(GyroSensitivity), 3f);
		GyroSensitivityRatio = CreateEntry(nameof(GyroSensitivityRatio), 1f,
			"Gyro vertical sensitivity ratio. 0.75 means vertical sensitivity is 75% slower"
		);
		GyroSpace = CreateEntry(nameof(GyroSpace), Core.GyroSpace.PlayerTurn,
			"Algorithm used to convert gyro input to camera turns. Player recommended for most cases, Local for handhelds. Play around with this!"
		);
		GyroButton = CreateEntry(nameof(GyroButton), ControllerButton.RightStick,
			"Controller button used for enabling/disabling gyro, based on GyroButtonMode. Not all buttons are usable on all controllers"
		);
		GyroButtonMode = CreateEntry(nameof(GyroButtonMode), Core.GyroButtonMode.Off,
			"Behavior of the gyro button"
		);
		GyroCalibrateButton = CreateEntry(nameof(GyroCalibrateButton), ControllerButton.TouchpadClick,
			"Controller button to calibrate gyro. Lay the controller on a flat surface and hold this button down for a second or two to correct gyro drift"
		);
		GyroTightening = CreateEntry(nameof(GyroTightening), 6f,
			"Rotations below this threshold get squeezed to 0, like a soft deadzone. Helps reduse effets of shaky hands"
		);
		GyroSmoothingThreshold = CreateEntry(nameof(GyroSmoothingThreshold), 0f,
			"Rotations below this threshold are smoothed. Helps reduce effects of shaky hands, but adds latency"
		);
		GyroSmoothingTime = CreateEntry(nameof(GyroSmoothingTime), 0.075f,
			"Amount of time to smooth gyro for when below threshold"
		);
		GyroAccelerationThresholdSlow = CreateEntry(nameof(GyroAccelerationThresholdSlow), 0f,
			"Rotation speed threshold at which to use GyroAccelerationSensitivitySlow"
		);
		GyroAccelerationThresholdFast = CreateEntry(nameof(GyroAccelerationThresholdFast), 75f,
			"Rotation speed threshold at which to use GyroAccelerationSensitivityFast"
		);
		GyroAccelerationSensitivitySlow = CreateEntry(nameof(GyroAccelerationSensitivitySlow), 1f,
			"Sensitivity to use when within the threshold GyroAccelerationThresholdSlow"
		);
		GyroAccelerationSensitivityFast = CreateEntry(nameof(GyroAccelerationSensitivityFast), 1f,
			"Sensitivity to use when within the threshold GyroAccelerationThresholdFast"
		);
		FlickStickEnabled = CreateEntry(nameof(FlickStickEnabled), true,
			"Replace right stick aiming with flick stick. Requires gyro to also be enabled"
		);
		FlickThreshold = CreateEntry(nameof(FlickThreshold), 0.9f,
			"Threshold to activate flick stick at. Values between 0.9 and 0.99 recommended"
		);
		FlickTime = CreateEntry(nameof(FlickTime), 0.1f,
			"Amount of time it takes to animate the initial flick"
		);
		FlickSnapping = CreateEntry(nameof(FlickSnapping), GyroHelpers.FlickSnapping.ForwardOnly,
			"Snap flicks to cardinal directions"
		);
		FlickForwardDeadzone = CreateEntry(nameof(FlickForwardDeadzone), 7f,
			"Forward flicks below this angle are ignored. Helps avoid unintended flicks when moving the stick up. Only applies when FlickSnapping is set to ForwardOnly"
		);
		FlickSmoothingThreshold = CreateEntry(nameof(FlickSmoothingThreshold), 2.3f,
			"Angle changes below this threshold are smoothed. Leave at default if unsure"
		);
		FlickSmoothingTime = CreateEntry(nameof(FlickSmoothingTime), 0.064f,
			"Amount of time to smooth flick stick for when below threshold. Leave at default if unsure"
		);
	}

	MelonLoaderConfigEntry<T> CreateEntry<T>(string name, T defaultValue, string? description = null)
	{
		return new(category.CreateEntry(name, defaultValue, description: description));
	}
}
