using System.Runtime.InteropServices;

namespace NeonGyro.SDL3;

public unsafe partial struct SDL_GUID
{
	public fixed byte data[16];
}

public static unsafe partial class SDL
{
	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void SDL_GUIDToString(SDL_GUID guid, byte* pszGUID, int cbGUID);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_GUID SDL_StringToGUID(byte* pchGUID);
}
