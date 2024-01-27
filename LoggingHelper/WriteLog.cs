using System;
using System.IO;

namespace LoggingHelper
{
    internal class WriteLog
    {
        internal static bool ToFile(string logPath, string message, string levelMessage, string nameMethod, string obs)
        {
        restart:
            try
            {
                using (StreamWriter writer = new StreamWriter(logPath, true))
                {
                    writer.Write($"{DateTime.Now} [{levelMessage}] ({nameMethod}) {message.Replace("\n", "").Replace("\r", "")}");

                    if (!string.IsNullOrEmpty(obs)) writer.Write($" | {obs.Replace("\n", "").Replace("\r", "")}");

                    writer.WriteLine();
                    return true;
                }
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
                string output = $"{DateTime.Now} [{levelMessage}] ({nameMethod}) {message.Replace("\n", "").Replace("\r", "")}";
                if (!string.IsNullOrEmpty(obs)) output += $" | {obs.Replace("\n", "").Replace("\r", "")}";

                switch (levelMessage)
                {
                    case nameof(LH.LoggingHelper.Level.TRACE):
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case nameof(LH.LoggingHelper.Level.DEBUG):
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case nameof(LH.LoggingHelper.Level.INFO):
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case nameof(LH.LoggingHelper.Level.WARNING):
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case nameof(LH.LoggingHelper.Level.ERROR):
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case nameof(LH.LoggingHelper.Level.CRITICAL):
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }

                Console.WriteLine(output);
                Console.ResetColor();
                return true;
            }
            catch
            {
                throw;
            }
        }





    }
}
