using System;
using System.Text.RegularExpressions;

namespace LH
{
    internal static class Treatment
    {
        internal static string FormatLog(string formatLog, string message, string levelMessage, string nameMethod, string obs)
        {
            // Default format: "<dd/MM/yyyy HH:mm:ss.fff> [<level>] (<stack>) <message> | <obs>"

            try
            {
                string formattedLog = formatLog
                    .Replace("<level>", levelMessage)
                    .Replace("<stack>", nameMethod)
                    .Replace("<message>", (message ?? "").Replace("\n", "").Replace("\r", ""));

                if (!string.IsNullOrEmpty(obs))
                {
                    formattedLog = formattedLog.Replace("<obs>", $"{obs.Replace("\n", "").Replace("\r", "")}");
                }
                else
                {
                    formattedLog = formattedLog.Replace(" | <obs>", "");
                    formattedLog = formattedLog.Replace("<obs>", "");
                }

                Match match = Regex.Match(formattedLog, @"<([^>]*)>");
                var formattedDateTime = match.Success ? match.Groups[1].Value : "dd/MM/yyyy HH:mm:ss.fff";

                formattedLog = formattedLog.Replace($"<{formattedDateTime}>", DateTime.Now.ToString(formattedDateTime));
                return formattedLog;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static int GetIntLevelMessage(object level)
        {
            try
            {
                int intLevelMessage;

                if (level is int levelInt) { intLevelMessage = levelInt; }
                else if (level is LoggingHelper.Level levelEnum) { intLevelMessage = (int)levelEnum; }
                else if (level is string levelStr)
                {
                    if (string.IsNullOrEmpty(levelStr.Trim())) throw new ArgumentException("E-00001-LH: Log message level cannot be null or empty!");
                    if (!Enum.TryParse<LoggingHelper.Level>(levelStr, out var levelEnumStr)) { throw new ArgumentException($"E-00002-LH: Log message level ({levelStr}) is not defined in 'Level' property!"); }

                    //intLevelMessage = (int)Enum.Parse(typeof(LoggingHelper.Level), levelStr);
                    intLevelMessage = (int)levelEnumStr;
                }
                else { throw new ArgumentException("Invalid level parameter.", nameof(level)); }

                if (intLevelMessage < 0) throw new ArgumentException($"E-00001-LH: Log message level ({intLevelMessage}) is invalid!");

                return intLevelMessage;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
