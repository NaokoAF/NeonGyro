using UnityEngine;

namespace NeonGyro.Core;

public static class Mod
{
	internal static ILogger Logger = new UnityDebugLogger();
	internal static SDLManager SDL = new();
	internal static ControllerManager? ControllerManager;
	internal static IConfig? Config;

	public static void Initialize(IConfig config)
	{
		Config = config;
		ControllerManager = new(SDL, config);

		// add logging
		SDL.ControllerAdded += controller => Logger.Msg($"Controller {controller.Id} added - {controller.Name} (Gyro: {controller.HasGyro})");
		SDL.ControllerRemoved += controller => Logger.Msg($"Controller {controller.Id} removed - {controller.Name}");
		ControllerManager.GyroBiasCalibrated += (controller, bias) => Logger.Msg($"Controller {controller.Id} calibrated - {controller.Name} (Bias: {bias})");
		ControllerManager.ActiveControllerChanged += controller =>
		{
			if (controller != null)
				Logger.Msg($"Set active controller to {controller.Id} - {controller.Name}");
			else
				Logger.Msg("No controller active!");
		};

		// initialize SDL
		Logger.Msg($"SDL {SDL.Version.Major}.{SDL.Version.Minor}.{SDL.Version.Micro} ({SDL.Revision})");
		if (!SDL.Init())
		{
			Logger.Msg($"Failed to initialize SDL: {SDL.CurrentError}");
		}
	}

	public static void Update()
	{
		ControllerManager!.PrePoll();
		SDL.Poll();

		ControllerManager!.GyroPaused = !Application.isFocused;
		ControllerManager!.Update(Time.unscaledDeltaTime);
	}

	public static void Deinitialize()
	{
		SDL.Quit();
	}
}