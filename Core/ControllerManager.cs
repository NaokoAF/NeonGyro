using NeonGyro.SDL3;
using System.Numerics;

namespace NeonGyro.Core;

public unsafe class ControllerManager
{
	public SDLController? ActiveController => activeController;
	public Vector2 GyroDelta => gyroDelta;
	public float FlickStickDelta => flickDelta;
	public bool GyroPaused { get; set; }

	public event Action<SDLController, Vector3>? GyroBiasCalibrated;
	public event Action<SDLController?>? ActiveControllerChanged;

	SDLManager sdl;
	IConfig config;
	SDLController? activeController;
	GyroState? activeControllerGyro;
	Vector2 gyroDelta;
	bool gyroButtonState = true;
	float flickDelta;
	Dictionary<SDLController, GyroState> gyroStates = new();

	public ControllerManager(SDLManager sdl, IConfig config)
	{
		this.sdl = sdl;
		this.config = config;
		sdl.ControllerAdded += Sdl_ControllerAdded;
		sdl.ControllerRemoved += Sdl_ControllerRemoved;
		sdl.ControllerButtonUpdated += Sdl_ControllerButtonUpdated;
		sdl.ControllerSensorUpdated += Sdl_ControllerSensorUpdated;
	}

	public void Update(float deltaTime)
	{
		int gyroButton = (int)config.GyroButton.Value;
		int gyroCalibrateButton = (int)config.GyroCalibrateButton.Value;

		// add up gyro on all controllers
		gyroDelta = Vector2.Zero;
		if (activeController != null && activeControllerGyro != null)
		{
			switch (config.GyroButtonMode.Value)
			{
				case GyroButtonMode.Off: gyroButtonState = !activeController.GetButton(gyroButton); break;
				case GyroButtonMode.On: gyroButtonState = activeController.GetButton(gyroButton); break;
			}

			if (activeController.GetButton(gyroCalibrateButton))
				activeControllerGyro.BiasCalibrationTime = 0.1f;

			if (gyroButtonState && !GyroPaused)
			{
				gyroDelta = activeControllerGyro.UpdateGyro(config, deltaTime);
			}
			else
			{
				activeControllerGyro.FlushGyro();
			}

			flickDelta = activeControllerGyro.UpdateFlickStick(config, activeController.RightStick, deltaTime);
		}
	}

	private void Sdl_ControllerAdded(SDLController controller)
	{
		if (controller.HasGyro)
		{
			GyroState gyro = new();
			gyro.BiasCalibrationTime = 1f; // calibrate once added
			gyro.BiasCalibrated += bias => GyroBiasCalibrated?.Invoke(controller, bias);
			gyroStates.Add(controller, gyro);
		}

		if (activeController == null)
			SetActiveController(controller);
	}

	void SetActiveController(SDLController? controller)
	{
		if (controller == activeController) return;

		activeController = controller;

		if (controller != null && gyroStates.TryGetValue(controller, out var gyro))
		{
			gyro.FlushGyro();
			activeControllerGyro = gyro;
		}
		else
		{
			activeControllerGyro = null;
		}
		ActiveControllerChanged?.Invoke(controller);
	}

	private void Sdl_ControllerRemoved(SDLController controller)
	{
		if (activeController == controller)
			SetActiveController(null);

		gyroStates.Remove(controller);
	}

	private void Sdl_ControllerButtonUpdated(SDLController controller, ControllerButton button, bool down)
	{
		SetActiveController(controller);

		// toggle gyro
		ControllerButton gyroButton = config.GyroButton.Value;
		ControllerButton gyroCalibrateButton = config.GyroCalibrateButton.Value;
		if (down && button == gyroButton && config.GyroButtonMode.Value == GyroButtonMode.Toggle)
		{
			gyroButtonState = !gyroButtonState;
		}
	}

	private void Sdl_ControllerSensorUpdated(SDLController controller, SDL_SensorType sensor, Vector3 data, ulong timestamp)
	{
		if (!config.GyroEnabled.Value) return; // skip for performance
		if (activeController != controller || activeControllerGyro == null) return;

		activeControllerGyro.InputGyro(controller.Gyroscope, controller.Accelerometer, controller.GyroscopeTimestamp);
	}
}
