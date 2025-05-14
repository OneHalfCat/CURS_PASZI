using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_7211_KIA_PASZI
{
    internal class Logger
    {
        private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
        public static string GetLogFilePath()
        {
            return logFilePath;
        }
        public static void Log(string message)
        {
            try
            {
                string timeStamped = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
                File.AppendAllText(logFilePath, timeStamped + Environment.NewLine);
            }
            catch
            {
                // Можно добавить вывод ошибки, но лучше не мешать пользователю
            }
        }

        public static string[] GetLogLines()
        {
            try
            {
                return File.ReadAllLines(logFilePath);
            }
            catch
            {
                return new string[0];
            }
        }
    }
}
