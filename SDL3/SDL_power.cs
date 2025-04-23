using System.Runtime.InteropServices;

namespace NeonGyro.SDL3;

public enum SDL_PowerState
{
	SDL_POWERSTATE_ERROR = -1,
	SDL_POWERSTATE_UNKNOWN,
	SDL_POWERSTATE_ON_BATTERY,
	SDL_POWERSTATE_NO_BATTERY,
	SDL_POWERSTATE_CHARGING,
	SDL_POWERSTATE_CHARGED,
}

public static unsafe partial class SDL
{
	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_PowerState SDL_GetPowerInfo(int* seconds, int* percent);
}
