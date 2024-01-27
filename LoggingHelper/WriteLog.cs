using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace LH
{
    internal class WriteLog
    {
        internal static bool ToFile(string logPath, string message, string levelMessage, string nameMethod, string obs)
        {
        restart:
            try
            {
                using (StreamWriter writer = new StreamWriter(logPath, true, Encoding.UTF8))
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
