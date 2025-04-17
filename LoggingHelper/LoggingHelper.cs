namespace LH
{
    /// <summary>
    /// Library for logging.
    /// </summary>
    public static class LoggingHelper
    {
        /// <summary>
        /// The default log object for static use.
        /// </summary>
        private static ILoggingHelper LogDefault = new LoggingHelperObj();

        /// <inheritdoc cref="ILoggingHelper.LevelStack"/>
        public static int LevelStack
        {
            get => LogDefault.LevelStack;
            set { LogDefault.LevelStack = value; }
        }

        /// <inheritdoc cref="ILoggingHelper.LogValidity"/>
        public static int LogValidity
        {
            get => LogDefault.LogValidity;
            set { LogDefault.LogValidity = value; }
        }

        /// <inheritdoc cref="ILoggingHelper.LogLevelFile"/>
        public static int LogLevelFile
        {
            get => LogDefault.LogLevelFile;
            set { LogDefault.LogLevelFile = value; }
        }

        /// <inheritdoc cref="ILoggingHelper.LogLevelTrace"/>
        public static int LogLevelTrace
        {
            get => LogDefault.LogLevelTrace;
            set { LogDefault.LogLevelTrace = value; }
        }

        /// <inheritdoc cref="ILoggingHelper.LogLevelConsole"/>
        public static int LogLevelConsole
        {
            get => LogDefault.LogLevelConsole;
            set { LogDefault.LogLevelConsole = value; }
        }

        /// <inheritdoc cref="ILoggingHelper.LogPathFile"/>
        public static string LogPathFile
        {
            get => LogDefault.LogPathFile;
            set { LogDefault.LogPathFile = value; CheckFile(LogValidity); }
        }

        /// <inheritdoc cref="ILoggingHelper.FormatLogOutput"/>       
        public static string FormatLogOutput
        {
            get => LogDefault.FormatLogOutput;
            set { LogDefault.FormatLogOutput = value; }
        }

        /// <summary>
        /// Log levels.
        /// </summary>
        public enum Level
        {
            /// <summary>
            /// Used only for tracing the code and trying to find a specific part of a function.
            /// </summary>
            TRACE,

            /// <summary>
            /// Information useful for diagnosis.
            /// </summary>
            DEBUG,

            /// <summary>
            /// Information generally useful for logging (start/stop of a service, configuration assumptions, etc.). Information I want to have available, but don't typically care about under normal circumstances.
            /// </summary>
            INFO,

            /// <summary>
            /// Anything that may cause strange behavior in the application, but for which I am automatically recovering.
            /// </summary>
            WARNING,

            /// <summary>
            /// Any error that is fatal to the operation but not the service or application (cannot open a needed file, missing data, etc.). These errors will force user (administrator or direct user) intervention. They are usually reserved for incorrect connection strings, missing services, etc.
            /// </summary>
            ERROR,

            /// <summary>
            /// Any error that is forcing a shutdown of the service or application to prevent further data loss (or further significant data loss). Typically used only for the most heinous errors and situations where there is guaranteed to have been an error that has caused some data corruption or loss.
            /// </summary>
            CRITICAL
        }

        /// <summary>
        /// Create a new log object.
        /// </summary>
        /// <returns>LoggingHelperObj</returns>
        public static LoggingHelperObj NewLog()
        {
            return new LoggingHelperObj();
        }

        /// <summary>
        /// Restores all properties to default values.
        /// </summary>
        /// <returns>True if the log was successfully reset; otherwise, false.</returns>
        public static bool ResetLog()
        {
            LogDefault = new LoggingHelperObj();
            return true;
        }

        /// <inheritdoc cref="ILoggingHelper.CheckFile(int, bool)"/>
        public static bool CheckFile(int days = 3, bool hidden = true)
        {
            return LogDefault.CheckFile(days, hidden);
        }

        /// <inheritdoc cref="ILoggingHelper.DeleteLogFile"/>
        public static bool DeleteLogFile()
        {
            return LogDefault.DeleteLogFile();
        }

        /// <inheritdoc cref="ILoggingHelper.Write(string, object, string)"/>
        public static bool Write(string message, object level, string obs)
        {
            return LogDefault.Write(message, level, obs);
        }

        /// <inheritdoc cref="ILoggingHelper.Trace(string, string)"/>
        public static bool Trace(string message, string obs = null)
        {
            return LogDefault.Trace(message, obs);
        }

        /// <inheritdoc cref="ILoggingHelper.Debug(string, string)"/>
        public static bool Debug(string message, string obs = null)
        {
            return LogDefault.Write(message, Level.DEBUG, obs);
        }

        /// <inheritdoc cref="ILoggingHelper.Info(string, string)"/>
        public static bool Info(string message, string obs = null)
        {
            return LogDefault.Write(message, Level.INFO, obs);
        }

        /// <inheritdoc cref="ILoggingHelper.Warning(string, string)"/>
        public static bool Warning(string message, string obs = null)
        {
            return LogDefault.Write(message, Level.WARNING, obs);
        }

        /// <inheritdoc cref="ILoggingHelper.Error(string, string)"/>
        public static bool Error(string message, string obs = null)
        {
            return LogDefault.Write(message, Level.ERROR, obs);
        }

        /// <inheritdoc cref="ILoggingHelper.Critical(string, string)"/>
        public static bool Critical(string message, string obs = null)
        {
            return LogDefault.Write(message, Level.CRITICAL, obs);
        }

        /// <inheritdoc cref="ILoggingHelper.GetCallingMethodName(int, int)"/>
        public static string GetCallingMethodName(int indStack, int levelPath)
        {
            return LogDefault.GetCallingMethodName(indStack, levelPath);
        }


    }
}

