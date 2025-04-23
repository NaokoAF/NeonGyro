using System.Runtime.InteropServices;

namespace NeonGyro.SDL3;

public static unsafe partial class SDL
{
	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_SetError(byte* fmt, __arglist);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_SetErrorV(byte* fmt, byte* ap);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_OutOfMemory();

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetError", ExactSpelling = true)]
	public static extern byte* Unsafe_SDL_GetError();

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_ClearError();
}