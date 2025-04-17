namespace LH
{
    internal interface ILoggingHelper
    {
        /// <summary>
        /// Maximum hierarchical level to be logged in the method stack (final index). Example: 5
        /// </summary>
        int LevelStack { get; set; }

        /// <summary>
        /// The number of days after which the log file should be considered outdated and will be deleted. Default is 3 days.
        /// </summary>
        int LogValidity { get; set; }

        /// <summary>
        /// Minimum level to be logged in the log file.
        /// <para>Example: If set to 2, TRACE and DEBUG logs will not be logged.</para>
        /// <para>Enter a negative number to avoid recording logs.</para>
        /// </summary>
        int LogLevelFile { get; set; }

        /// <summary>
        /// Minimum level to be logged in the log trace.
        /// <para>Example: If set to 2, TRACE and DEBUG logs will not be logged.</para>
        /// <para>Enter a negative number to avoid recording logs.</para>
        /// </summary>
        int LogLevelTrace { get; set; }

        /// <summary>
        /// Minimum level to be logged in the log console.
        /// <para>Example: If set to 2, TRACE and DEBUG logs will not be logged.</para>
        /// <para>Enter a negative number to avoid recording logs.</para>
        /// </summary>
        int LogLevelConsole { get; set; }

        /// <summary>
        /// Location where the log file will be stored.
        /// (Specify a different location or filename to use different log files).
        /// </summary>
        string LogPathFile { get; set; }

        /// <summary>
        /// Log template. Use placeholders between &lt; and &gt;.
        /// Example: "&lt;dd/MM/yyyy HH:mm:ss.fff&gt; [&lt;level&gt;] (&lt;stack&gt;) &lt;message&gt; | &lt;obs&gt;"
        /// </summary>
        string FormatLogOutput { get; set; }

        /// <summary>
        /// Checks if the log file is older than a specified number of days and deletes it if necessary. It also checks if the directory is valid and creates it if it doesn't exist.
        /// </summary>
        /// <param name="days">The number of days after which the log file should be considered outdated. Default is 3 days.</param>
        /// <param name="hidden">Specifies whether the directory should be hidden. Default is true.</param>
        bool CheckFile(int days = 3, bool hidden = true);

        /// <summary>
        /// Deletes the log file defined in the LogPath attribute.
        /// </summary>
        /// <returns>True if the file was successfully deleted, otherwise false.</returns>
        bool DeleteLogFile();

        /// <summary>
        /// Write a message to the log.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="level">Set the level of this log. TRACE = 0, DEBUG = 1, INFO = 2, WARNING = 3, ERROR = 4, CRITICAL = 5</param>
        /// <param name="obs">Provide any additional information you deem necessary (optional)</param>
        /// <returns>Returns true if the log was written successfully; otherwise, returns false</returns>
        bool Write(string message, object level, string obs);

        /// <summary>
        /// Write a message to the log at the TRACE level.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="obs">Provide any additional information you deem necessary (optional)</param>
        /// <returns>Returns true if the log was written successfully; otherwise, returns false</returns>
        bool Trace(string message, string obs = null);

        /// <summary>
        /// Write a message to the log at the DEBUG level.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="obs">Provide any additional information you deem necessary (optional)</param>
        /// <returns>Returns true if the log was written successfully; otherwise, returns false</returns>
        bool Debug(string message, string obs = null);

        /// <summary>
        /// Write a message to the log at the INFO level.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="obs">Provide any additional information you deem necessary (optional)</param>
        /// <returns>Returns true if the log was written successfully; otherwise, returns false</returns>
        bool Info(string message, string obs = null);

        /// <summary>
        /// Write a message to the log at the WARNING level.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="obs">Provide any additional information you deem necessary (optional)</param>
        /// <returns>Returns true if the log was written successfully; otherwise, returns false</returns>
        bool Warning(string message, string obs = null);

        /// <summary>
        /// Write a message to the log at the ERROR level.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="obs">Provide any additional information you deem necessary (optional)</param>
        /// <returns>Returns true if the log was written successfully; otherwise, returns false</returns>
        bool Error(string message, string obs = null);

        /// <summary>
        /// Write a message to the log at the CRITICAL level.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="obs">Provide any additional information you deem necessary (optional)</param>
        /// <returns>Returns true if the log was written successfully; otherwise, returns false</returns>
        bool Critical(string message, string obs = null);

        /// <summary>
        /// Identifies the name of the calling method (stack).
        /// </summary>
        /// <param name="indStack">Initial index for the call stack. E.g., if 2, it analyzes from the antepenultimate call.</param>
        /// <param name="levelPath">Maximum hierarchical level to be recorded in the method path (end index). E.g., 5.</param>
        /// <returns>The name of the calling method (stack).</returns>
        string GetCallingMethodName(int indStack, int levelPath);

    }
}
