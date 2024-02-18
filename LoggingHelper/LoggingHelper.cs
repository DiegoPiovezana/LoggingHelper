using System.Diagnostics;
using System.Text;

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
        public static readonly LoggingHelperObj LogDefault = new LoggingHelperObj();

        /// <summary>
        /// Maximum hierarchical level to be logged in the method stack (final index). Example: 5
        /// </summary>
        public static int LevelStack
        {
            get => LogDefault.LevelStack;
            set { LogDefault.LevelStack = value; }
        }

        /// <summary>
        /// The number of days after which the log file should be considered outdated and will be deleted. Default is 3 days.
        /// </summary>
        public static int LogValidity
        {
            get => LogDefault.LogValidity;
            set { LogDefault.LogValidity = value; }
        }

        /// <summary>
        /// Minimum level to be logged in the log file.
        /// <para>Example: If set to 2, TRACE and DEBUG logs will not be logged.</para>
        /// <para>Enter a negative number to avoid recording logs.</para>
        /// </summary>
        public static int LogLevelFile
        {
            get => LogDefault.LogLevelFile;
            set { LogDefault.LogLevelFile = value; }
        }

        /// <summary>
        /// Minimum level to be logged in the log trace.
        /// <para>Example: If set to 2, TRACE and DEBUG logs will not be logged.</para>
        /// <para>Enter a negative number to avoid recording logs.</para>
        /// </summary>
        public static int LogLevelTrace
        {
            get => LogDefault.LogLevelTrace;
            set { LogDefault.LogLevelTrace = value; }
        }

        /// <summary>
        /// Minimum level to be logged in the log console.
        /// <para>Example: If set to 2, TRACE and DEBUG logs will not be logged.</para>
        /// <para>Enter a negative number to avoid recording logs.</para>
        /// </summary>
        public static int LogLevelConsole
        {
            get => LogDefault.LogLevelConsole;
            set { LogDefault.LogLevelConsole = value; }
        }       

        /// <summary>
        /// Location where the log file will be stored.
        /// (Specify a different location or filename to use different log files).
        /// </summary>
        public static string LogPathFile
        {
            get => LogDefault.LogPathFile;
            set { LogDefault.LogPathFile = value; CheckFile(LogValidity); }
        }

        /// <summary>
        /// The format of the log message.
        /// </summary>        
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
        /// <returns></returns>
        public static LoggingHelperObj NewLog()
        {
            return new LoggingHelperObj();
        }





        /// <summary>
        /// Checks if the log file is older than a specified number of days and deletes it if necessary. It also checks if the directory is valid and creates it if it doesn't exist.
        /// </summary>
        /// <param name="days">The number of days after which the log file should be considered outdated. Default is 3 days.</param>
        /// <param name="hidden">Specifies whether the directory should be hidden. Default is true.</param>
        public static bool CheckFile(int days = 3, bool hidden = true)
        {
            return LogDefault.CheckFile(days, hidden);
        }

        /// <summary>
        /// Deletes the log file defined in the LogPath attribute.
        /// </summary>
        /// <returns>True if the file was successfully deleted, otherwise false.</returns>
        public static bool DeleteLogFile()
        {
            return LogDefault.DeleteLogFile();
        }

        /// <summary>
        /// Write a message to the log file.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="level">Set the level of this log. TRACE = 0, DEBUG = 1, INFO = 2, WARNING = 3, ERROR = 4, CRITICAL = 5</param>
        /// <param name="obs">Provide any additional information you deem necessary (optional)</param>
        /// <returns>Returns true if the log was written successfully; otherwise, returns false</returns>
        public static bool Write(string message, object level, string obs)
        {
            return LogDefault.Write(message, level, obs);
        }



        /// <summary>
        /// Identifies the name of the calling method (stack).
        /// </summary>
        /// <param name="indStack">Initial index for the call stack. E.g., if 2, it analyzes from the antepenultimate call.</param>
        /// <param name="levelPath">Maximum hierarchical level to be recorded in the method path (end index). E.g., 5.</param>
        /// <returns>The name of the calling method (stack).</returns>
        public static string GetCallingMethodName(int indStack, int levelPath)
        {
            return LogDefault.GetCallingMethodName(indStack, levelPath);
        }


    }
}

