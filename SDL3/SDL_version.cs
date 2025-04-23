using System.Runtime.InteropServices;

namespace NeonGyro.SDL3;

public static unsafe partial class SDL
{
	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int SDL_GetVersion();

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRevision", ExactSpelling = true)]
	public static extern byte* Unsafe_SDL_GetRevision();
}
