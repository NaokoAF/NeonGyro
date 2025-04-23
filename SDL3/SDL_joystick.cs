using System.Runtime.InteropServices;

namespace NeonGyro.SDL3;

public enum SDL_JoystickID : uint;

public partial struct SDL_Joystick { }

public enum SDL_JoystickType
{
	SDL_JOYSTICK_TYPE_UNKNOWN,
	SDL_JOYSTICK_TYPE_GAMEPAD,
	SDL_JOYSTICK_TYPE_WHEEL,
	SDL_JOYSTICK_TYPE_ARCADE_STICK,
	SDL_JOYSTICK_TYPE_FLIGHT_STICK,
	SDL_JOYSTICK_TYPE_DANCE_PAD,
	SDL_JOYSTICK_TYPE_GUITAR,
	SDL_JOYSTICK_TYPE_DRUM_KIT,
	SDL_JOYSTICK_TYPE_ARCADE_PAD,
	SDL_JOYSTICK_TYPE_THROTTLE,
	SDL_JOYSTICK_TYPE_COUNT,
}

public enum SDL_JoystickConnectionState
{
	SDL_JOYSTICK_CONNECTION_INVALID = -1,
	SDL_JOYSTICK_CONNECTION_UNKNOWN,
	SDL_JOYSTICK_CONNECTION_WIRED,
	SDL_JOYSTICK_CONNECTION_WIRELESS,
}

public unsafe partial struct SDL_VirtualJoystickTouchpadDesc
{
	public ushort nfingers;
	public fixed ushort padding[3];
}

public partial struct SDL_VirtualJoystickSensorDesc
{
	public SDL_SensorType type;

	public float rate;
}

public unsafe partial struct SDL_VirtualJoystickDesc
{
	public uint version;
	public ushort type;
	public ushort padding;
	public ushort vendor_id;
	public ushort product_id;
	public ushort naxes;
	public ushort nbuttons;
	public ushort nballs;
	public ushort nhats;
	public ushort ntouchpads;
	public ushort nsensors;
	public fixed ushort padding2[2];
	public uint button_mask;
	public uint axis_mask;
	public byte* name;
	public SDL_VirtualJoystickTouchpadDesc* touchpads;
	public SDL_VirtualJoystickSensorDesc* sensors;
	public IntPtr userdata;
	public delegate* unmanaged[Cdecl]<IntPtr, void> Update;
	public delegate* unmanaged[Cdecl]<IntPtr, int, void> SetPlayerIndex;
	public delegate* unmanaged[Cdecl]<IntPtr, ushort, ushort, SDLBool> Rumble;
	public delegate* unmanaged[Cdecl]<IntPtr, ushort, ushort, SDLBool> RumbleTriggers;
	public delegate* unmanaged[Cdecl]<IntPtr, byte, byte, byte, SDLBool> SetLED;
	public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int, SDLBool> SendEffect;
	public delegate* unmanaged[Cdecl]<IntPtr, SDLBool, SDLBool> SetSensorsEnabled;
	public delegate* unmanaged[Cdecl]<IntPtr, void> Cleanup;
}

public static unsafe partial class SDL
{
	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void SDL_LockJoysticks();

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void SDL_UnlockJoysticks();

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_HasJoystick();

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_JoystickID* SDL_GetJoysticks(int* count);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetJoystickNameForID", ExactSpelling = true)]
	public static extern byte* Unsafe_SDL_GetJoystickNameForID(SDL_JoystickID instance_id);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetJoystickPathForID", ExactSpelling = true)]
	public static extern byte* Unsafe_SDL_GetJoystickPathForID(SDL_JoystickID instance_id);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int SDL_GetJoystickPlayerIndexForID(SDL_JoystickID instance_id);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_GUID SDL_GetJoystickGUIDForID(SDL_JoystickID instance_id);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern ushort SDL_GetJoystickVendorForID(SDL_JoystickID instance_id);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern ushort SDL_GetJoystickProductForID(SDL_JoystickID instance_id);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern ushort SDL_GetJoystickProductVersionForID(SDL_JoystickID instance_id);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_JoystickType SDL_GetJoystickTypeForID(SDL_JoystickID instance_id);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_Joystick* SDL_OpenJoystick(SDL_JoystickID instance_id);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_Joystick* SDL_GetJoystickFromID(SDL_JoystickID instance_id);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_Joystick* SDL_GetJoystickFromPlayerIndex(int player_index);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_JoystickID SDL_AttachVirtualJoystick(SDL_VirtualJoystickDesc* desc);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_DetachVirtualJoystick(SDL_JoystickID instance_id);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_IsJoystickVirtual(SDL_JoystickID instance_id);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_SetJoystickVirtualAxis(SDL_Joystick* joystick, int axis, short value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_SetJoystickVirtualBall(SDL_Joystick* joystick, int ball, short xrel, short yrel);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_SetJoystickVirtualButton(SDL_Joystick* joystick, int button, SDLBool down);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_SetJoystickVirtualHat(SDL_Joystick* joystick, int hat, byte value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_SetJoystickVirtualTouchpad(SDL_Joystick* joystick, int touchpad, int finger, SDLBool down, float x, float y, float pressure);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_SendJoystickVirtualSensorData(SDL_Joystick* joystick, SDL_SensorType type, ulong sensor_timestamp, float* data, int num_values);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_PropertiesID SDL_GetJoystickProperties(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetJoystickName", ExactSpelling = true)]
	public static extern byte* Unsafe_SDL_GetJoystickName(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetJoystickPath", ExactSpelling = true)]
	public static extern byte* Unsafe_SDL_GetJoystickPath(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int SDL_GetJoystickPlayerIndex(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_SetJoystickPlayerIndex(SDL_Joystick* joystick, int player_index);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_GUID SDL_GetJoystickGUID(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern ushort SDL_GetJoystickVendor(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern ushort SDL_GetJoystickProduct(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern ushort SDL_GetJoystickProductVersion(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern ushort SDL_GetJoystickFirmwareVersion(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetJoystickSerial", ExactSpelling = true)]
	public static extern byte* Unsafe_SDL_GetJoystickSerial(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_JoystickType SDL_GetJoystickType(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void SDL_GetJoystickGUIDInfo(SDL_GUID guid, ushort* vendor, ushort* product, ushort* version, ushort* crc16);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_JoystickConnected(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_JoystickID SDL_GetJoystickID(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int SDL_GetNumJoystickAxes(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int SDL_GetNumJoystickBalls(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int SDL_GetNumJoystickHats(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int SDL_GetNumJoystickButtons(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void SDL_SetJoystickEventsEnabled(SDLBool enabled);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_JoystickEventsEnabled();

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void SDL_UpdateJoysticks();

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern short SDL_GetJoystickAxis(SDL_Joystick* joystick, int axis);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_GetJoystickAxisInitialState(SDL_Joystick* joystick, int axis, short* state);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_GetJoystickBall(SDL_Joystick* joystick, int ball, int* dx, int* dy);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern byte SDL_GetJoystickHat(SDL_Joystick* joystick, int hat);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_GetJoystickButton(SDL_Joystick* joystick, int button);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_RumbleJoystick(SDL_Joystick* joystick, ushort low_frequency_rumble, ushort high_frequency_rumble, uint duration_ms);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_RumbleJoystickTriggers(SDL_Joystick* joystick, ushort left_rumble, ushort right_rumble, uint duration_ms);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_SetJoystickLED(SDL_Joystick* joystick, byte red, byte green, byte blue);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_SendJoystickEffect(SDL_Joystick* joystick, IntPtr data, int size);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void SDL_CloseJoystick(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_JoystickConnectionState SDL_GetJoystickConnectionState(SDL_Joystick* joystick);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_PowerState SDL_GetJoystickPowerInfo(SDL_Joystick* joystick, int* percent);

	public const int SDL_JOYSTICK_AXIS_MAX = 32767;
	public const int SDL_JOYSTICK_AXIS_MIN = -32768;

	public const uint SDL_HAT_CENTERED = 0x00U;
	public const uint SDL_HAT_UP = 0x01U;
	public const uint SDL_HAT_RIGHT = 0x02U;
	public const uint SDL_HAT_DOWN = 0x04U;
	public const uint SDL_HAT_LEFT = 0x08U;
	public const uint SDL_HAT_RIGHTUP = (0x02U | 0x01U);
	public const uint SDL_HAT_RIGHTDOWN = (0x02U | 0x04U);
	public const uint SDL_HAT_LEFTUP = (0x08U | 0x01U);
	public const uint SDL_HAT_LEFTDOWN = (0x08U | 0x04U);
}