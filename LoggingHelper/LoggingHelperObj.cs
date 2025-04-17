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
    public class LoggingHelperObj : ILoggingHelper
    {
        /// <inheritdoc/>
        public int LevelStack { get; set; } = 4;

        /// <inheritdoc/>
        public int LogValidity { get; set; } = 3;

        /// <inheritdoc/>
        public int LogLevelFile { get; set; } = 0;

        /// <inheritdoc/>
        public int LogLevelTrace { get; set; } = -1;

        /// <inheritdoc/>
        public int LogLevelConsole { get; set; } = 0;

        private bool _firstChecked = false;
        private string _logPath = ".\\LOG_LH\\Logging_general.log";

        /// <inheritdoc/>
        public string LogPathFile
        {
            get => _logPath;
            set { _logPath = value; CheckFile(LogValidity); }
        }

        /// <inheritdoc/>
        public string FormatLogOutput { get; set; } = "<dd/MM/yyyy HH:mm:ss.fff> [<level>] (<stack>) <message> | <obs>"; // "{0} [{1}] ({2}) {3}{4}"


        /// <inheritdoc cref="LoggingHelper.Level"/>
        public enum Level
        {
            /// <inheritdoc cref="LoggingHelper.Level.TRACE"/>
            TRACE,

            /// <inheritdoc cref="LoggingHelper.Level.DEBUG"/>
            DEBUG,

            /// <inheritdoc cref="LoggingHelper.Level.INFO"/>
            INFO,

            /// <inheritdoc cref="LoggingHelper.Level.WARNING"/>
            WARNING,

            /// <inheritdoc cref="LoggingHelper.Level.ERROR"/>
            ERROR,

            /// <inheritdoc cref="LoggingHelper.Level.CRITICAL"/>
            CRITICAL
        }




        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public bool Write(string message, object level, string obs)
        {
            int intLevelMessage = Treatment.GetIntLevelMessage(level);

            string callingMethod = GetCallingMethodName(2, LevelStack);

            if (LogLevelTrace >= 0 && intLevelMessage >= LogLevelTrace)
            {
                WriteLog.ToTrace(message, ((Level)intLevelMessage).ToString(), callingMethod, obs);
            }

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

        /// <inheritdoc/>
        public bool Trace(string message, string obs = null)
        {
            return Write(message, Level.TRACE, obs);
        }

        /// <inheritdoc/>
        public bool Debug(string message, string obs = null)
        {
            return Write(message, Level.DEBUG, obs);
        }

        /// <inheritdoc/>
        public bool Info(string message, string obs = null)
        {
            return Write(message, Level.INFO, obs);
        }

        /// <inheritdoc/>
        public bool Warning(string message, string obs = null)
        {
            return Write(message, Level.WARNING, obs);
        }

        /// <inheritdoc/>
        public bool Error(string message, string obs = null)
        {
            return Write(message, Level.ERROR, obs);
        }

        /// <inheritdoc/>
        public bool Critical(string message, string obs = null)
        {
            return Write(message, Level.CRITICAL, obs);
        }

        /// <inheritdoc/>
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

