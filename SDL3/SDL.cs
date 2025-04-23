using System.Text;

namespace NeonGyro.SDL3;

public static unsafe partial class SDL
{
	public static string? PtrToStringUTF8(byte* ptr, bool free = false)
	{
		if (ptr == null) return null;

		// find first null character
		int length = 0;
		while (ptr[length] != (byte)'\0')
			length++;

		string s = Encoding.UTF8.GetString(ptr, length);
		if (free) SDL_free((IntPtr)ptr);
		return s;
	}
}
