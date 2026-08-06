using System;

// задание 5.9
namespace MiniAutomationToolkit.Core.Services
{
    public class ErrorLogger
    {
        public string? TryReadFile(string sourceFilePath, string logFilePath) // возвращает содержимое исходного файла
        {
            try
            {
                var file = File.ReadAllText(sourceFilePath);
                return file;
            }
            catch (FileNotFoundException exFile)
            {

                var logDate = DateTime.Now;
                var logType = exFile.GetType().Name;
                var logMessage = exFile.Message;

                var logLine = $"{logDate} | {logType} | {logMessage}{Environment.NewLine}";

                File.AppendAllText(logFilePath, logLine); // сохраняет эту строку по пути
                return null;

            }


            catch (UnauthorizedAccessException exAccess)
            {
                var logDate = DateTime.Now;
                var logType = exAccess.GetType().Name;
                var logMessage = exAccess.Message;

                var logLine = $"{logDate} | {logType} | {logMessage} {Environment.NewLine}";

                File.AppendAllText(logFilePath, logLine); // сохраняет эту строку по пути
                return null;
            }

        }
    }
}
