using System;

namespace DocumentsKeeperDemo.Core.Infrastructure
{
	/// <summary>
	/// The application logger class.
	/// </summary>
	public static class ApplicationLogger
	{
		/// <summary>
		/// The log4net logger.
		/// </summary>
		private static readonly log4net.ILog log4netLogger;

		/// <summary>
		/// This static constructor initializes a logger.
		/// </summary>
		static ApplicationLogger()
		{
			ApplicationLogger.log4netLogger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		}

		/// <summary>
		/// Writes info log message.
		/// </summary>
		/// <param name="infoMessage">The info message.</param>
		public static void LogInfo(string infoMessage)
		{
			log4netLogger.Info(infoMessage);
		}

		/// <summary>
		/// Writes warning log message.
		/// </summary>
		/// <param name="warningMessage">The warning message.</param>
		public static void LogWarning(string warningMessage)
		{
			log4netLogger.Warn(warningMessage);
		}

		/// <summary>
		/// Writes error log message.
		/// </summary>
		/// <param name="errorMessage">The error log message.</param>
		public static void LogError(string errorMessage)
		{
			log4netLogger.Error(errorMessage);
		}

		/// <summary>
		/// Writes error log message with exception info.
		/// </summary>
		/// <param name="errorMessage">The error message.</param>
		/// <param name="exception">The exception.</param>
		public static void LogError(string errorMessage, Exception exception)
		{
			log4netLogger.Error(errorMessage, exception);
		}
	}
}
