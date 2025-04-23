using System.Runtime.InteropServices;

namespace NeonGyro.SDL3;

public enum SDL_SensorID : uint;

public partial struct SDL_Sensor
{
}

public enum SDL_SensorType
{
	SDL_SENSOR_INVALID = -1,
	SDL_SENSOR_UNKNOWN,
	SDL_SENSOR_ACCEL,
	SDL_SENSOR_GYRO,
	SDL_SENSOR_ACCEL_L,
	SDL_SENSOR_GYRO_L,
	SDL_SENSOR_ACCEL_R,
	SDL_SENSOR_GYRO_R,
}

public static unsafe partial class SDL
{
	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_SensorID* SDL_GetSensors(int* count);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSensorNameForID", ExactSpelling = true)]
	public static extern byte* Unsafe_SDL_GetSensorNameForID(SDL_SensorID instance_id);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_SensorType SDL_GetSensorTypeForID(SDL_SensorID instance_id);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int SDL_GetSensorNonPortableTypeForID(SDL_SensorID instance_id);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_Sensor* SDL_OpenSensor(SDL_SensorID instance_id);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_Sensor* SDL_GetSensorFromID(SDL_SensorID instance_id);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_PropertiesID SDL_GetSensorProperties(SDL_Sensor* sensor);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSensorName", ExactSpelling = true)]
	public static extern byte* Unsafe_SDL_GetSensorName(SDL_Sensor* sensor);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_SensorType SDL_GetSensorType(SDL_Sensor* sensor);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern int SDL_GetSensorNonPortableType(SDL_Sensor* sensor);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDL_SensorID SDL_GetSensorID(SDL_Sensor* sensor);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern SDLBool SDL_GetSensorData(SDL_Sensor* sensor, float* data, int num_values);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void SDL_CloseSensor(SDL_Sensor* sensor);

	[DllImport("SDL3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	public static extern void SDL_UpdateSensors();

	public const float SDL_STANDARD_GRAVITY = 9.80665f;
}