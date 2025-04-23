using NeonGyro.SDL3;
using System.Numerics;
using static NeonGyro.SDL3.SDL;

namespace NeonGyro.Core;

public unsafe class SDLManager
{
	public SDLVersion Version => version;
	public string? Revision => revision;
	public string? CurrentError => PtrToStringUTF8(Unsafe_SDL_GetError());

	public event Action<SDLController>? ControllerAdded;
	public event Action<SDLController>? ControllerRemoved;
	public event Action<SDLController, ControllerButton, bool>? ControllerButtonUpdated;
	public event Action<SDLController, ControllerAxis, float>? ControllerAxisUpdated;
	public event Action<SDLController, SDL_SensorType, Vector3, ulong>? ControllerSensorUpdated;

	Dictionary<SDL_JoystickID, SDLController> controllers = new();
	SDLVersion version;
	string? revision;

	public SDLManager()
	{
		version = new SDLVersion(SDL_GetVersion());
		revision = PtrToStringUTF8(Unsafe_SDL_GetRevision());
	}

	public bool Init()
	{
		if (!SDL_Init(SDL_InitFlags.SDL_INIT_JOYSTICK | SDL_InitFlags.SDL_INIT_GAMEPAD))
			return false;

		SDL_SetGamepadEventsEnabled(true); // enable controller events
		return true;
	}

	public void Quit()
	{
		SDL_Quit();
	}

	public void Poll()
	{
		// must update joysticks for rumble to work (since we don't listen to joystick events)
		SDL_UpdateJoysticks();

		SDL_Event evnt;
		while (SDL_PollEvent(&evnt))
		{
			switch ((SDL_EventType)evnt.type)
			{
				case SDL_EventType.SDL_EVENT_GAMEPAD_ADDED:
					OnControllerAdded(evnt.gdevice);
					break;
				case SDL_EventType.SDL_EVENT_GAMEPAD_REMOVED:
					OnControllerRemoved(evnt.gdevice);
					break;
				case SDL_EventType.SDL_EVENT_GAMEPAD_SENSOR_UPDATE:
					OnControllerSensorUpdate(evnt.gsensor);
					break;
				case SDL_EventType.SDL_EVENT_GAMEPAD_BUTTON_DOWN:
				case SDL_EventType.SDL_EVENT_GAMEPAD_BUTTON_UP:
					OnControllerButtonUpdate(evnt.gbutton);
					break;
				case SDL_EventType.SDL_EVENT_GAMEPAD_AXIS_MOTION:
					OnControllerAxisUpdate(evnt.gaxis);
					break;
			}
		}
	}

	void OnControllerAdded(SDL_GamepadDeviceEvent evnt)
	{
		// open and create controller
		SDL_JoystickID id = evnt.which;
		SDL_Gamepad* gamepad = SDL_OpenGamepad(id);
		if (gamepad == null) return; // error

		SDLController controller = new(id, gamepad);
		if (controller.HasGyro)
			controller.SetGyroEnabled(controller.HasGyro);

		// add to dictionary and raise event
		controllers.Add(id, controller);
		ControllerAdded?.Invoke(controller);
	}

	void OnControllerRemoved(SDL_GamepadDeviceEvent evnt)
	{
		if (!controllers.TryGetValue(evnt.which, out var controller)) return;

		SDL_CloseGamepad(controller.Gamepad); // likely unecessary

		controllers.Remove(evnt.which);
		ControllerRemoved?.Invoke(controller);
	}

	void OnControllerButtonUpdate(SDL_GamepadButtonEvent evnt)
	{
		if (!controllers.TryGetValue(evnt.which, out var controller)) return;
		controller.SetButton(evnt.button, evnt.down);

		ControllerButtonUpdated?.Invoke(controller, (ControllerButton)evnt.button, evnt.down);
	}

	void OnControllerAxisUpdate(SDL_GamepadAxisEvent evnt)
	{
		if (!controllers.TryGetValue(evnt.which, out var controller)) return;

		ControllerAxis axis = (ControllerAxis)evnt.axis;
		float value = evnt.value / 32767f;
		switch (axis)
		{
			case ControllerAxis.LeftStickX: controller.LeftStick.X = value; break;
			case ControllerAxis.LeftStickY: controller.LeftStick.Y = value; break;
			case ControllerAxis.RightStickX: controller.RightStick.X = value; break;
			case ControllerAxis.RightStickY: controller.RightStick.Y = value; break;
			case ControllerAxis.LeftTrigger: controller.LeftTrigger = value; break;
			case ControllerAxis.RightTrigger: controller.RightTrigger = value; break;
		}
		ControllerAxisUpdated?.Invoke(controller, axis, value);
	}

	void OnControllerSensorUpdate(SDL_GamepadSensorEvent evnt)
	{
		if (!controllers.TryGetValue(evnt.which, out var controller)) return;

		SDL_SensorType type = (SDL_SensorType)evnt.sensor;
		ulong timestamp = evnt.sensor_timestamp; // timestamp in nanoseconds
		Vector3 data = *(Vector3*)evnt.data; // convert 3 float pointer to a Vector3
		switch (type)
		{
			case SDL_SensorType.SDL_SENSOR_GYRO:
				controller.Gyroscope = data;
				controller.GyroscopeTimestamp = timestamp;
				break;
			case SDL_SensorType.SDL_SENSOR_ACCEL:
				controller.Accelerometer = data;
				controller.AccelerometerTimestamp = timestamp;
				break;
		}

		ControllerSensorUpdated?.Invoke(controller, type, data, timestamp);
	}
}
