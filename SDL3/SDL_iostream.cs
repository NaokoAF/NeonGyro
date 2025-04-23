using System.Runtime.InteropServices;

namespace NeonGyro.SDL3;

public enum SDL_IOStatus
{
	SDL_IO_STATUS_READY,
	SDL_IO_STATUS_ERROR,
	SDL_IO_STATUS_EOF,
	SDL_IO_STATUS_NOT_READY,
	SDL_IO_STATUS_READONLY,
	SDL_IO_STATUS_WRITEONLY,
}

public enum SDL_IOWhence
{
	SDL_IO_SEEK_SET,
	SDL_IO_SEEK_CUR,
	SDL_IO_SEEK_END,
}

public unsafe partial struct SDL_IOStreamInterface
{
	public uint version;
	public delegate* unmanaged[Cdecl]<IntPtr, long> size;
	public delegate* unmanaged[Cdecl]<IntPtr, long, SDL_IOWhence, long> seek;
	public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, nuint, SDL_IOStatus*, nuint> read;
	public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, nuint, SDL_IOStatus*, nuint> write;
	public delegate* unmanaged[Cdecl]<IntPtr, SDL_IOStatus*, SDLBool> flush;
	public delegate* unmanaged[Cdecl]<IntPtr, SDLBool> close;
}

public partial struct SDL_IOStream
{
}

public static unsafe partial class SDL
{
	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_IOStream* SDL_IOFromFile(byte* file, byte* mode);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_IOStream* SDL_IOFromMem(IntPtr mem, nuint size);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_IOStream* SDL_IOFromConstMem(IntPtr mem, nuint size);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_IOStream* SDL_IOFromDynamicMem();

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_IOStream* SDL_OpenIO(SDL_IOStreamInterface* iface, IntPtr userdata);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_CloseIO(SDL_IOStream* context);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_PropertiesID SDL_GetIOProperties(SDL_IOStream* context);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_IOStatus SDL_GetIOStatus(SDL_IOStream* context);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern long SDL_GetIOSize(SDL_IOStream* context);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern long SDL_SeekIO(SDL_IOStream* context, long offset, SDL_IOWhence whence);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern long SDL_TellIO(SDL_IOStream* context);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern nuint SDL_ReadIO(SDL_IOStream* context, IntPtr ptr, nuint size);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern nuint SDL_WriteIO(SDL_IOStream* context, IntPtr ptr, nuint size);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern nuint SDL_IOprintf(SDL_IOStream* context, byte* fmt, __arglist);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern nuint SDL_IOvprintf(SDL_IOStream* context, byte* fmt, byte* ap);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_FlushIO(SDL_IOStream* context);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern IntPtr SDL_LoadFile_IO(SDL_IOStream* src, nuint* datasize, SDLBool closeio);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern IntPtr SDL_LoadFile(byte* file, nuint* datasize);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_SaveFile_IO(SDL_IOStream* src, IntPtr data, nuint datasize, SDLBool closeio);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_SaveFile(byte* file, IntPtr data, nuint datasize);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_ReadU8(SDL_IOStream* src, byte* value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_ReadS8(SDL_IOStream* src, sbyte* value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_ReadU16LE(SDL_IOStream* src, ushort* value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_ReadS16LE(SDL_IOStream* src, short* value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_ReadU16BE(SDL_IOStream* src, ushort* value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_ReadS16BE(SDL_IOStream* src, short* value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_ReadU32LE(SDL_IOStream* src, uint* value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_ReadS32LE(SDL_IOStream* src, int* value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_ReadU32BE(SDL_IOStream* src, uint* value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_ReadS32BE(SDL_IOStream* src, int* value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_ReadU64LE(SDL_IOStream* src, ulong* value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_ReadS64LE(SDL_IOStream* src, long* value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_ReadU64BE(SDL_IOStream* src, ulong* value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_ReadS64BE(SDL_IOStream* src, long* value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_WriteU8(SDL_IOStream* dst, byte value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_WriteS8(SDL_IOStream* dst, sbyte value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_WriteU16LE(SDL_IOStream* dst, ushort value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_WriteS16LE(SDL_IOStream* dst, short value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_WriteU16BE(SDL_IOStream* dst, ushort value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_WriteS16BE(SDL_IOStream* dst, short value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_WriteU32LE(SDL_IOStream* dst, uint value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_WriteS32LE(SDL_IOStream* dst, int value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_WriteU32BE(SDL_IOStream* dst, uint value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_WriteS32BE(SDL_IOStream* dst, int value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_WriteU64LE(SDL_IOStream* dst, ulong value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_WriteS64LE(SDL_IOStream* dst, long value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_WriteU64BE(SDL_IOStream* dst, ulong value);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_WriteS64BE(SDL_IOStream* dst, long value);
}