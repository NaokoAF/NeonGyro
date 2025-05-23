﻿using System.Runtime.InteropServices;
namespace NeonGyro.SDL3;

public enum SDL_EventType
{
	SDL_EVENT_FIRST = 0,
	SDL_EVENT_QUIT = 0x100,
	SDL_EVENT_TERMINATING,
	SDL_EVENT_LOW_MEMORY,
	SDL_EVENT_WILL_ENTER_BACKGROUND,
	SDL_EVENT_DID_ENTER_BACKGROUND,
	SDL_EVENT_WILL_ENTER_FOREGROUND,
	SDL_EVENT_DID_ENTER_FOREGROUND,
	SDL_EVENT_LOCALE_CHANGED,
	SDL_EVENT_SYSTEM_THEME_CHANGED,
	SDL_EVENT_DISPLAY_ORIENTATION = 0x151,
	SDL_EVENT_DISPLAY_ADDED,
	SDL_EVENT_DISPLAY_REMOVED,
	SDL_EVENT_DISPLAY_MOVED,
	SDL_EVENT_DISPLAY_DESKTOP_MODE_CHANGED,
	SDL_EVENT_DISPLAY_CURRENT_MODE_CHANGED,
	SDL_EVENT_DISPLAY_CONTENT_SCALE_CHANGED,
	SDL_EVENT_DISPLAY_FIRST = SDL_EVENT_DISPLAY_ORIENTATION,
	SDL_EVENT_DISPLAY_LAST = SDL_EVENT_DISPLAY_CONTENT_SCALE_CHANGED,
	SDL_EVENT_WINDOW_SHOWN = 0x202,
	SDL_EVENT_WINDOW_HIDDEN,
	SDL_EVENT_WINDOW_EXPOSED,
	SDL_EVENT_WINDOW_MOVED,
	SDL_EVENT_WINDOW_RESIZED,
	SDL_EVENT_WINDOW_PIXEL_SIZE_CHANGED,
	SDL_EVENT_WINDOW_METAL_VIEW_RESIZED,
	SDL_EVENT_WINDOW_MINIMIZED,
	SDL_EVENT_WINDOW_MAXIMIZED,
	SDL_EVENT_WINDOW_RESTORED,
	SDL_EVENT_WINDOW_MOUSE_ENTER,
	SDL_EVENT_WINDOW_MOUSE_LEAVE,
	SDL_EVENT_WINDOW_FOCUS_GAINED,
	SDL_EVENT_WINDOW_FOCUS_LOST,
	SDL_EVENT_WINDOW_CLOSE_REQUESTED,
	SDL_EVENT_WINDOW_HIT_TEST,
	SDL_EVENT_WINDOW_ICCPROF_CHANGED,
	SDL_EVENT_WINDOW_DISPLAY_CHANGED,
	SDL_EVENT_WINDOW_DISPLAY_SCALE_CHANGED,
	SDL_EVENT_WINDOW_SAFE_AREA_CHANGED,
	SDL_EVENT_WINDOW_OCCLUDED,
	SDL_EVENT_WINDOW_ENTER_FULLSCREEN,
	SDL_EVENT_WINDOW_LEAVE_FULLSCREEN,
	SDL_EVENT_WINDOW_DESTROYED,
	SDL_EVENT_WINDOW_HDR_STATE_CHANGED,
	SDL_EVENT_WINDOW_FIRST = SDL_EVENT_WINDOW_SHOWN,
	SDL_EVENT_WINDOW_LAST = SDL_EVENT_WINDOW_HDR_STATE_CHANGED,
	SDL_EVENT_KEY_DOWN = 0x300,
	SDL_EVENT_KEY_UP,
	SDL_EVENT_TEXT_EDITING,
	SDL_EVENT_TEXT_INPUT,
	SDL_EVENT_KEYMAP_CHANGED,
	SDL_EVENT_KEYBOARD_ADDED,
	SDL_EVENT_KEYBOARD_REMOVED,
	SDL_EVENT_TEXT_EDITING_CANDIDATES,
	SDL_EVENT_MOUSE_MOTION = 0x400,
	SDL_EVENT_MOUSE_BUTTON_DOWN,
	SDL_EVENT_MOUSE_BUTTON_UP,
	SDL_EVENT_MOUSE_WHEEL,
	SDL_EVENT_MOUSE_ADDED,
	SDL_EVENT_MOUSE_REMOVED,
	SDL_EVENT_JOYSTICK_AXIS_MOTION = 0x600,
	SDL_EVENT_JOYSTICK_BALL_MOTION,
	SDL_EVENT_JOYSTICK_HAT_MOTION,
	SDL_EVENT_JOYSTICK_BUTTON_DOWN,
	SDL_EVENT_JOYSTICK_BUTTON_UP,
	SDL_EVENT_JOYSTICK_ADDED,
	SDL_EVENT_JOYSTICK_REMOVED,
	SDL_EVENT_JOYSTICK_BATTERY_UPDATED,
	SDL_EVENT_JOYSTICK_UPDATE_COMPLETE,
	SDL_EVENT_GAMEPAD_AXIS_MOTION = 0x650,
	SDL_EVENT_GAMEPAD_BUTTON_DOWN,
	SDL_EVENT_GAMEPAD_BUTTON_UP,
	SDL_EVENT_GAMEPAD_ADDED,
	SDL_EVENT_GAMEPAD_REMOVED,
	SDL_EVENT_GAMEPAD_REMAPPED,
	SDL_EVENT_GAMEPAD_TOUCHPAD_DOWN,
	SDL_EVENT_GAMEPAD_TOUCHPAD_MOTION,
	SDL_EVENT_GAMEPAD_TOUCHPAD_UP,
	SDL_EVENT_GAMEPAD_SENSOR_UPDATE,
	SDL_EVENT_GAMEPAD_UPDATE_COMPLETE,
	SDL_EVENT_GAMEPAD_STEAM_HANDLE_UPDATED,
	SDL_EVENT_FINGER_DOWN = 0x700,
	SDL_EVENT_FINGER_UP,
	SDL_EVENT_FINGER_MOTION,
	SDL_EVENT_FINGER_CANCELED,
	SDL_EVENT_CLIPBOARD_UPDATE = 0x900,
	SDL_EVENT_DROP_FILE = 0x1000,
	SDL_EVENT_DROP_TEXT,
	SDL_EVENT_DROP_BEGIN,
	SDL_EVENT_DROP_COMPLETE,
	SDL_EVENT_DROP_POSITION,
	SDL_EVENT_AUDIO_DEVICE_ADDED = 0x1100,
	SDL_EVENT_AUDIO_DEVICE_REMOVED,
	SDL_EVENT_AUDIO_DEVICE_FORMAT_CHANGED,
	SDL_EVENT_SENSOR_UPDATE = 0x1200,
	SDL_EVENT_PEN_PROXIMITY_IN = 0x1300,
	SDL_EVENT_PEN_PROXIMITY_OUT,
	SDL_EVENT_PEN_DOWN,
	SDL_EVENT_PEN_UP,
	SDL_EVENT_PEN_BUTTON_DOWN,
	SDL_EVENT_PEN_BUTTON_UP,
	SDL_EVENT_PEN_MOTION,
	SDL_EVENT_PEN_AXIS,
	SDL_EVENT_CAMERA_DEVICE_ADDED = 0x1400,
	SDL_EVENT_CAMERA_DEVICE_REMOVED,
	SDL_EVENT_CAMERA_DEVICE_APPROVED,
	SDL_EVENT_CAMERA_DEVICE_DENIED,
	SDL_EVENT_RENDER_TARGETS_RESET = 0x2000,
	SDL_EVENT_RENDER_DEVICE_RESET,
	SDL_EVENT_RENDER_DEVICE_LOST,
	SDL_EVENT_PRIVATE0 = 0x4000,
	SDL_EVENT_PRIVATE1,
	SDL_EVENT_PRIVATE2,
	SDL_EVENT_PRIVATE3,
	SDL_EVENT_POLL_SENTINEL = 0x7F00,
	SDL_EVENT_USER = 0x8000,
	SDL_EVENT_LAST = 0xFFFF,
	SDL_EVENT_ENUM_PADDING = 0x7FFFFFFF,
}

public partial struct SDL_CommonEvent
{
	public uint type;
	public uint reserved;
	public ulong timestamp;
}

public partial struct SDL_DisplayEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_DisplayID displayID;
	//public int data1;
	//public int data2;
}

public partial struct SDL_WindowEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_WindowID windowID;
	//public int data1;
	//public int data2;
}

public partial struct SDL_KeyboardDeviceEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_KeyboardID which;
}

public partial struct SDL_KeyboardEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_WindowID windowID;
	//public SDL_KeyboardID which;
	//public SDL_Scancode scancode;
	//public SDL_Keycode key;
	//public SDL_Keymod mod;
	//public ushort raw;
	//public SDLBool down;
	//public SDLBool repeat;
}

public unsafe partial struct SDL_TextEditingEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_WindowID windowID;
	//public byte* text;
	//public int start;
	//public int length;
}

public unsafe partial struct SDL_TextEditingCandidatesEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_WindowID windowID;
	//public byte** candidates;
	//public int num_candidates;
	//public int selected_candidate;
	//public SDLBool horizontal;
	//public byte padding1;
	//public byte padding2;
	//public byte padding3;
}

public unsafe partial struct SDL_TextInputEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_WindowID windowID;
	//public byte* text;
}

public partial struct SDL_MouseDeviceEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_MouseID which;
}

public partial struct SDL_MouseMotionEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_WindowID windowID;
	//public SDL_MouseID which;
	//public SDL_MouseButtonFlags state;
	//public float x;
	//public float y;
	//public float xrel;
	//public float yrel;
}

public partial struct SDL_MouseButtonEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_WindowID windowID;
	//public SDL_MouseID which;
	//public byte button;
	//public SDLBool down;
	//public byte clicks;
	//public byte padding;
	//public float x;
	//public float y;
}

public partial struct SDL_MouseWheelEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_WindowID windowID;
	//public SDL_MouseID which;
	//public float x;
	//public float y;
	//public SDL_MouseWheelDirection direction;
	//public float mouse_x;
	//public float mouse_y;
}

public partial struct SDL_JoyAxisEvent
{
	public SDL_EventType type;
	public uint reserved;
	public ulong timestamp;
	public SDL_JoystickID which;
	public byte axis;
	public byte padding1;
	public byte padding2;
	public byte padding3;
	public short value;
	public ushort padding4;
}

public partial struct SDL_JoyBallEvent
{
	public SDL_EventType type;
	public uint reserved;
	public ulong timestamp;
	public SDL_JoystickID which;
	public byte ball;
	public byte padding1;
	public byte padding2;
	public byte padding3;
	public short xrel;
	public short yrel;
}

public partial struct SDL_JoyHatEvent
{
	public SDL_EventType type;
	public uint reserved;
	public ulong timestamp;
	public SDL_JoystickID which;
	public byte hat;
	public byte value;
	public byte padding1;
	public byte padding2;
}

public partial struct SDL_JoyButtonEvent
{
	public SDL_EventType type;
	public uint reserved;
	public ulong timestamp;
	public SDL_JoystickID which;
	public byte button;
	public SDLBool down;
	public byte padding1;
	public byte padding2;
}

public partial struct SDL_JoyDeviceEvent
{
	public SDL_EventType type;
	public uint reserved;
	public ulong timestamp;
	public SDL_JoystickID which;
}

public partial struct SDL_JoyBatteryEvent
{
	public SDL_EventType type;
	public uint reserved;
	public ulong timestamp;
	public SDL_JoystickID which;
	public SDL_PowerState state;
	public int percent;
}

public partial struct SDL_GamepadAxisEvent
{
	public SDL_EventType type;
	public uint reserved;
	public ulong timestamp;
	public SDL_JoystickID which;
	public byte axis;
	public byte padding1;
	public byte padding2;
	public byte padding3;
	public short value;
	public ushort padding4;
}

public partial struct SDL_GamepadButtonEvent
{
	public SDL_EventType type;
	public uint reserved;
	public ulong timestamp;
	public SDL_JoystickID which;
	public byte button;
	public SDLBool down;
	public byte padding1;
	public byte padding2;
}

public partial struct SDL_GamepadDeviceEvent
{
	public SDL_EventType type;
	public uint reserved;
	public ulong timestamp;
	public SDL_JoystickID which;
}

public partial struct SDL_GamepadTouchpadEvent
{
	public SDL_EventType type;
	public uint reserved;
	public ulong timestamp;
	public SDL_JoystickID which;
	public int touchpad;
	public int finger;
	public float x;
	public float y;
	public float pressure;
}

public unsafe partial struct SDL_GamepadSensorEvent
{
	public SDL_EventType type;
	public uint reserved;
	public ulong timestamp;
	public SDL_JoystickID which;
	public int sensor;
	public fixed float data[3];
	public ulong sensor_timestamp;
}

public partial struct SDL_AudioDeviceEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_AudioDeviceID which;
	//public SDLBool recording;
	//public byte padding1;
	//public byte padding2;
	//public byte padding3;
}

public partial struct SDL_CameraDeviceEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_CameraID which;
}

public partial struct SDL_RenderEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_WindowID windowID;
}

public partial struct SDL_TouchFingerEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_TouchID touchID;
	//public SDL_FingerID fingerID;
	//public float x;
	//public float y;
	//public float dx;
	//public float dy;
	//public float pressure;
	//public SDL_WindowID windowID;
}

public partial struct SDL_PenProximityEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_WindowID windowID;
	//public SDL_PenID which;
}

public partial struct SDL_PenMotionEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_WindowID windowID;
	//public SDL_PenID which;
	//public SDL_PenInputFlags pen_state;
	//public float x;
	//public float y;
}

public partial struct SDL_PenTouchEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_WindowID windowID;
	//public SDL_PenID which;
	//public SDL_PenInputFlags pen_state;
	//public float x;
	//public float y;
	//public SDLBool eraser;
	//public SDLBool down;
}

public partial struct SDL_PenButtonEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_WindowID windowID;
	//public SDL_PenID which;
	//public SDL_PenInputFlags pen_state;
	//public float x;
	//public float y;
	//public byte button;
	//public SDLBool down;
}

public partial struct SDL_PenAxisEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_WindowID windowID;
	//public SDL_PenID which;
	//public SDL_PenInputFlags pen_state;
	//public float x;
	//public float y;
	//public SDL_PenAxis axis;
	//public float value;
}

public unsafe partial struct SDL_DropEvent
{
	//public SDL_EventType type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_WindowID windowID;
	//public float x;
	//public float y;
	//public byte* source;
	//public byte* data;
}

public unsafe partial struct SDL_ClipboardEvent
{
	public SDL_EventType type;
	public uint reserved;
	public ulong timestamp;
	public SDLBool owner;
	public int num_mime_types;
	public byte** mime_types;
}

public unsafe partial struct SDL_SensorEvent
{
	public SDL_EventType type;
	public uint reserved;
	public ulong timestamp;
	public SDL_SensorID which;
	public fixed float data[6];
	public ulong sensor_timestamp;
}

public partial struct SDL_QuitEvent
{
	public SDL_EventType type;
	public uint reserved;
	public ulong timestamp;
}

public partial struct SDL_UserEvent
{
	//public uint type;
	//public uint reserved;
	//public ulong timestamp;
	//public SDL_WindowID windowID;
	//public int code;
	//public IntPtr data1;
	//public IntPtr data2;
}
[StructLayout(LayoutKind.Explicit)]

public unsafe partial struct SDL_Event
{
	[FieldOffset(0)]
	public uint type;
	[FieldOffset(0)]
	public SDL_CommonEvent common;
	[FieldOffset(0)]
	public SDL_DisplayEvent display;
	[FieldOffset(0)]
	public SDL_WindowEvent window;
	[FieldOffset(0)]
	public SDL_KeyboardDeviceEvent kdevice;
	[FieldOffset(0)]
	public SDL_KeyboardEvent key;
	[FieldOffset(0)]
	public SDL_TextEditingEvent edit;
	[FieldOffset(0)]
	public SDL_TextEditingCandidatesEvent edit_candidates;
	[FieldOffset(0)]
	public SDL_TextInputEvent text;
	[FieldOffset(0)]
	public SDL_MouseDeviceEvent mdevice;
	[FieldOffset(0)]
	public SDL_MouseMotionEvent motion;
	[FieldOffset(0)]
	public SDL_MouseButtonEvent button;
	[FieldOffset(0)]
	public SDL_MouseWheelEvent wheel;
	[FieldOffset(0)]
	public SDL_JoyDeviceEvent jdevice;
	[FieldOffset(0)]
	public SDL_JoyAxisEvent jaxis;
	[FieldOffset(0)]
	public SDL_JoyBallEvent jball;
	[FieldOffset(0)]
	public SDL_JoyHatEvent jhat;
	[FieldOffset(0)]
	public SDL_JoyButtonEvent jbutton;
	[FieldOffset(0)]
	public SDL_JoyBatteryEvent jbattery;
	[FieldOffset(0)]
	public SDL_GamepadDeviceEvent gdevice;
	[FieldOffset(0)]
	public SDL_GamepadAxisEvent gaxis;
	[FieldOffset(0)]
	public SDL_GamepadButtonEvent gbutton;
	[FieldOffset(0)]
	public SDL_GamepadTouchpadEvent gtouchpad;
	[FieldOffset(0)]
	public SDL_GamepadSensorEvent gsensor;
	[FieldOffset(0)]
	public SDL_AudioDeviceEvent adevice;
	[FieldOffset(0)]
	public SDL_CameraDeviceEvent cdevice;
	[FieldOffset(0)]
	public SDL_SensorEvent sensor;
	[FieldOffset(0)]
	public SDL_QuitEvent quit;
	[FieldOffset(0)]
	public SDL_UserEvent user;
	[FieldOffset(0)]
	public SDL_TouchFingerEvent tfinger;
	[FieldOffset(0)]
	public SDL_PenProximityEvent pproximity;
	[FieldOffset(0)]
	public SDL_PenTouchEvent ptouch;
	[FieldOffset(0)]
	public SDL_PenMotionEvent pmotion;
	[FieldOffset(0)]
	public SDL_PenButtonEvent pbutton;
	[FieldOffset(0)]
	public SDL_PenAxisEvent paxis;
	[FieldOffset(0)]
	public SDL_RenderEvent render;
	[FieldOffset(0)]
	public SDL_DropEvent drop;
	[FieldOffset(0)]
	public SDL_ClipboardEvent clipboard;
	[FieldOffset(0)]
	public fixed byte padding[128];
}

public enum SDL_EventAction
{
	SDL_ADDEVENT,
	SDL_PEEKEVENT,
	SDL_GETEVENT,
}

public static unsafe partial class SDL
{
	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void SDL_PumpEvents();

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int SDL_PeepEvents(SDL_Event* events, int numevents, SDL_EventAction action, uint minType, uint maxType);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_HasEvent(uint type);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_HasEvents(uint minType, uint maxType);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void SDL_FlushEvent(uint type);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void SDL_FlushEvents(uint minType, uint maxType);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_PollEvent(SDL_Event* @event);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_WaitEvent(SDL_Event* @event);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_WaitEventTimeout(SDL_Event* @event, int timeoutMS);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_PushEvent(SDL_Event* @event);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void SDL_SetEventFilter(delegate* unmanaged[Cdecl]<IntPtr, SDL_Event*, SDLBool> filter, IntPtr userdata);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_GetEventFilter(delegate* unmanaged[Cdecl]<IntPtr, SDL_Event*, SDLBool>* filter, IntPtr* userdata);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_AddEventWatch(delegate* unmanaged[Cdecl]<IntPtr, SDL_Event*, SDLBool> filter, IntPtr userdata);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void SDL_RemoveEventWatch(delegate* unmanaged[Cdecl]<IntPtr, SDL_Event*, SDLBool> filter, IntPtr userdata);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void SDL_FilterEvents(delegate* unmanaged[Cdecl]<IntPtr, SDL_Event*, SDLBool> filter, IntPtr userdata);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void SDL_SetEventEnabled(uint type, SDLBool enabled);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_EventEnabled(uint type);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern uint SDL_RegisterEvents(int numevents);

	//[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	//public static extern SDL_Window* SDL_GetWindowFromEvent([NativeTypeName("const SDL_Event *")] SDL_Event* @event);
}