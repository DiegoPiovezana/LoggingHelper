using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LH
{
    /// <summary>
    /// Library for logging.
    /// </summary>
    public class LoggingHelperObj
    {
        /// <summary>
        /// Maximum hierarchical level to be logged in the method stack (final index). Example: 5
        /// </summary>
        public int LevelStack { get; set; } = 4;

        /// <summary>
        /// The number of days after which the log file should be considered outdated and will be deleted. Default is 3 days.
        /// </summary>
        public int LogValidity { get; set; } = 3;

        /// <summary>
        /// Minimum level to be logged in the log file.
        /// <para>Example: If set to 2, TRACE and DEBUG logs will not be logged.</para>
        /// <para>Enter a negative number to avoid recording logs.</para>
        /// </summary>
        public int LogLevelFile { get; set; } = 0;

        /// <summary>
        /// Minimum level to be logged in the log console.
        /// <para>Example: If set to 2, TRACE and DEBUG logs will not be logged.</para>
        /// <para>Enter a negative number to avoid recording logs.</para>
        /// </summary>
        public int LogLevelConsole { get; set; } = -1;


        private bool _firstChecked = false;
        private string _logPath = ".\\LOG_LH\\Logging_general.log";

        /// <summary>
        /// Location where the log file will be stored.
        /// (Specify a different location or filename to use different log files).
        /// </summary>
        public string LogPathFile
        {
            get => _logPath;
            set { _logPath = value; CheckFile(LogValidity); }
        }

        /// <summary>
        /// The format of the log message.
        /// </summary>
        public string FormatLogOutput { get; set; } = "<dd/MM/yyyy HH:mm:ss.fff> [<level>] (<stack>) <message> | <obs>"; // "{0} [{1}] ({2}) {3}{4}"


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
        /// Checks if the log file is older than a specified number of days and deletes it if necessary. It also checks if the directory is valid and creates it if it doesn't exist.
        /// </summary>
        /// <param name="days">The number of days after which the log file should be considered outdated. Default is 3 days.</param>
        /// <param name="hidden">Specifies whether the directory should be hidden. Default is true.</param>
        public bool CheckFile(int days = 3, bool hidden = true)
        {
            _firstChecked = true;

            DirectoryInfo di = Directory.CreateDirectory(Path.GetDirectoryName(LogPathFile));
            if (hidden) di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            else di.Attributes = FileAttributes.Directory & ~FileAttributes.Hidden;

            if (File.Exists(LogPathFile))
            {
                DateTime creationLog = File.GetCreationTime(LogPathFile);
                if ((DateTime.Now - creationLog).TotalDays > days) DeleteLogFile();
            }
            return true;
        }

        /// <summary>
        /// Deletes the log file defined in the LogPath attribute.
        /// </summary>
        /// <returns>True if the file was successfully deleted, otherwise false.</returns>
        public bool DeleteLogFile()
        {
            if (File.Exists(LogPathFile))
            {
                try
                {
                    File.Delete(LogPathFile);
                    return true;
                }
                catch (Exception)
                {
                    // Handle exception or log error if necessary
                    return false;
                }
            }

            return true; // If the file doesn't exist, consider it as deleted
        }        

        /// <summary>
        /// Write a message to the log file.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="level">Set the level of this log. TRACE = 0, DEBUG = 1, INFO = 2, WARNING = 3, ERROR = 4, CRITICAL = 5</param>
        /// <param name="obs">Provide any additional information you deem necessary (optional)</param>
        /// <returns>Returns true if the log was written successfully; otherwise, returns false</returns>
        public bool Write(string message, object level, string obs)
        {
            int intLevelMessage = Treatment.GetIntLevelMessage(level);

            string callingMethod = GetCallingMethodName(2, LevelStack);

            if (LogLevelConsole >= 0 && intLevelMessage >= LogLevelConsole)
            {
                WriteLog.ToConsole(message, ((Level)intLevelMessage).ToString(), callingMethod, obs);
            }

            if (LogLevelFile >= 0 && intLevelMessage >= LogLevelFile)
            {
                if (!_firstChecked) { CheckFile(LogValidity); } // TODO: change to when to boot                

                Task<bool> task = Task.Run(() => WriteLog.ToFile(LogPathFile, message, ((Level)intLevelMessage).ToString(), callingMethod, obs));

                // Wait for log writing for a maximum of 5 seconds
                if (task.Wait(TimeSpan.FromSeconds(5))) return task.Result;
                else return false; // If the time has expired, do not write
            }

            return true;
        }

        /// <summary>
        /// Identifies the name of the calling method (stack).
        /// </summary>
        /// <param name="indStack">Initial index for the call stack. E.g., if 2, it analyzes from the antepenultimate call.</param>
        /// <param name="levelPath">Maximum hierarchical level to be recorded in the method path (end index). E.g., 5.</param>
        /// <returns>The name of the calling method (stack).</returns>
        public string GetCallingMethodName(int indStack, int levelPath)
        {
            StackFrame frame = new StackFrame(indStack);
            StringBuilder nameMethod = new StringBuilder();

            for (int i = 1; frame.GetILOffset() != -1 && i <= levelPath; i++)
            {
                nameMethod.Insert(0, "/" + frame.GetMethod().Name); // Get the name of the calling method

                frame = new StackFrame(indStack + i); // Next previous frame
            }

            return nameMethod.ToString();
        }



    }
}

