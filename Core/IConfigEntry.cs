namespace NeonGyro.Core;

public interface IConfigEntry<T>
{
	T Value { get; set; }
}