using MelonLoader;
using NeonGyro.Core;
using NeonGyro.MelonLoader;

[assembly: MelonInfo(typeof(MelonLoaderMod), ModInfo.Name, ModInfo.Version, ModInfo.Author, null)]
[assembly: MelonGame("Little Flag Software, LLC", "Neon White")]
namespace NeonGyro.MelonLoader;

public class MelonLoaderMod : MelonMod
{
	public override void OnInitializeMelon()
	{
		HarmonyLib.Harmony harmony = new(ModInfo.Guid);
		harmony.PatchAll(typeof(MelonLoaderMod).Assembly);

		Mod.Logger = new MelonLoaderLogger(LoggerInstance);
		Mod.Initialize(new MelonLoaderConfig());
	}

	public override void OnUpdate()
	{
		Mod.Update();
	}

	public override void OnDeinitializeMelon()
	{
		Mod.Deinitialize();
	}
}