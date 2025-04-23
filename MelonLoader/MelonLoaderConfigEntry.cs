using MelonLoader;
using NeonGyro.Core;

namespace NeonGyro.MelonLoader;

public class MelonLoaderConfigEntry<T> : IConfigEntry<T>
{
	public T Value { get => entry.Value; set => entry.Value = value; }

	MelonPreferences_Entry<T> entry;

	public MelonLoaderConfigEntry(MelonPreferences_Entry<T> entry)
	{
		this.entry = entry;
	}
}