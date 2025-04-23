using System.Runtime.InteropServices;

namespace NeonGyro.SDL3;

[Flags]
public enum SDL_InitFlags : uint
{
	SDL_INIT_AUDIO = SDL.SDL_INIT_AUDIO,
	SDL_INIT_VIDEO = SDL.SDL_INIT_VIDEO,
	SDL_INIT_JOYSTICK = SDL.SDL_INIT_JOYSTICK,
	SDL_INIT_HAPTIC = SDL.SDL_INIT_HAPTIC,
	SDL_INIT_GAMEPAD = SDL.SDL_INIT_GAMEPAD,
	SDL_INIT_EVENTS = SDL.SDL_INIT_EVENTS,
	SDL_INIT_SENSOR = SDL.SDL_INIT_SENSOR,
	SDL_INIT_CAMERA = SDL.SDL_INIT_CAMERA,
}

public enum SDL_AppResult
{
	SDL_APP_CONTINUE,
	SDL_APP_SUCCESS,
	SDL_APP_FAILURE,
}

public static unsafe partial class SDL
{
	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_Init(SDL_InitFlags flags);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_InitSubSystem(SDL_InitFlags flags);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void SDL_QuitSubSystem(SDL_InitFlags flags);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_InitFlags SDL_WasInit(SDL_InitFlags flags);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void SDL_Quit();

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_IsMainThread();

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_RunOnMainThread(delegate* unmanaged[Cdecl]<IntPtr, void> callback, IntPtr userdata, SDLBool wait_complete);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_SetAppMetadata(byte* appname, byte* appversion, byte* appidentifier);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_SetAppMetadataProperty(byte* name, byte* value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAppMetadataProperty", ExactSpelling = true)]
	public static extern byte* Unsafe_SDL_GetAppMetadataProperty(byte* name);

	public const uint SDL_INIT_AUDIO = 0x00000010U;
	public const uint SDL_INIT_VIDEO = 0x00000020U;
	public const uint SDL_INIT_JOYSTICK = 0x00000200U;
	public const uint SDL_INIT_HAPTIC = 0x00001000U;
	public const uint SDL_INIT_GAMEPAD = 0x00002000U;
	public const uint SDL_INIT_EVENTS = 0x00004000U;
	public const uint SDL_INIT_SENSOR = 0x00008000U;
	public const uint SDL_INIT_CAMERA = 0x00010000U;
}