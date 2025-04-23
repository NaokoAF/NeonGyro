using MelonLoader;
using NeonGyro.Core;

namespace NeonGyro.MelonLoader;

public class MelonLoaderLogger : ILogger
{
	MelonLogger.Instance logger;

	public MelonLoaderLogger(MelonLogger.Instance logger)
	{
		this.logger = logger;
	}

	public void Error(string message)
	{
		logger.Error(message);
	}

	public void Msg(string message)
	{
		logger.Msg(message);
	}

	public void Warning(string message)
	{
		logger.Warning(message);
	}
}
