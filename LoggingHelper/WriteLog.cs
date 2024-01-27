using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace LH
{
    internal class WriteLog
    {
        private static string FormatLog(string formatLog, string message, string levelMessage, string nameMethod, string obs)
        {
            // Default format: "<dd/MM/yyyy HH:mm:ss.fff> [<level>] (<stack>) <message> | <obs>"

            try
            {
                string formattedLog = formatLog
                    .Replace("<level>", levelMessage)
                    .Replace("<stack>", nameMethod)
                    .Replace("<message>", message.Replace("\n", "").Replace("\r", ""));

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

        internal static bool ToFile(string logPath, string message, string levelMessage, string nameMethod, string obs)
        {
        restart:
            try
            {
                var output = FormatLog(LoggingHelper.FormatLogOutput, message, levelMessage, nameMethod, obs);

                using (StreamWriter writer = new StreamWriter(logPath, true, Encoding.UTF8))
                {
                    //writer.Write($"{DateTime.Now} [{levelMessage}] ({nameMethod}) {message.Replace("\n", "").Replace("\r", "")}");

                    //if (!string.IsNullOrEmpty(obs)) writer.Write($" | {obs.Replace("\n", "").Replace("\r", "")}");

                    writer.Write(output);
                    writer.WriteLine();
                }
                return true;
            }
            catch (IOException ex) when (ex.HResult == -2147024864) // If the log file is in use, try again
            {
                goto restart;
            }
            catch
            {
                throw;
            }
        }

        internal static bool ToConsole(string message, string levelMessage, string nameMethod, string obs)
        {
            try
            {
                //string output = $"{DateTime.Now} [{levelMessage}] ({nameMethod}) {message.Replace("\n", "").Replace("\r", "")}";
                //if (!string.IsNullOrEmpty(obs)) output += $" | {obs.Replace("\n", "").Replace("\r", "")}";

                var output = FormatLog(LoggingHelper.FormatLogOutput, message, levelMessage, nameMethod, obs);

                switch (levelMessage)
                {
                    case nameof(LoggingHelper.Level.TRACE):
                        //Console.ForegroundColor = ConsoleColor.DarkGray;
                        Trace.WriteLine(output);
                        break;
                    case nameof(LoggingHelper.Level.DEBUG):
                        //Console.ForegroundColor = ConsoleColor.Gray;
                        Trace.WriteLine(output);
                        //Debug.WriteLine(output);
                        break;
                    case nameof(LoggingHelper.Level.INFO):
                        //Console.ForegroundColor = ConsoleColor.White;
                        Trace.WriteLine(output);
                        break;
                    case nameof(LoggingHelper.Level.WARNING):
                        //Console.ForegroundColor = ConsoleColor.Yellow;
                        Trace.WriteLine(output);
                        break;
                    case nameof(LoggingHelper.Level.ERROR):
                        //Console.ForegroundColor = ConsoleColor.Red;
                        Trace.WriteLine(output);
                        //Console.Error.WriteLine(output);
                        break;
                    case nameof(LoggingHelper.Level.CRITICAL):
                        //Console.ForegroundColor = ConsoleColor.DarkRed;
                        Trace.WriteLine(output);
                        //Console.Error.WriteLine(output);
                        break;
                    default:
                        //Console.ForegroundColor = ConsoleColor.White;
                        Trace.WriteLine(output);
                        break;
                }

                //Debug.WriteLine(output);
                //Console.ResetColor();
                return true;
            }
            catch
            {
                throw;
            }
        }





    }
}
