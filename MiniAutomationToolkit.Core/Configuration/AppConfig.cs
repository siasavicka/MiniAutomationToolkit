using System;
using System.Collections.Generic;

namespace MiniAutomationToolkit.Core.Configuration
{
    public class AppConfig
    {
        Dictionary<string, string> _settings = new Dictionary<string, string>(); // Создаём поле и записываем в него словарь

        public AppConfig(string filePath)
        {
            var lines = File.ReadLines(filePath); // читаем строки файла


            foreach (var line in lines)
            {

                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (line.TrimStart().StartsWith("#"))
                {
                    continue;
                }
                var editedLine = line.Split("=", 2);
                if (editedLine.Length != 2)
                {
                    throw new InvalidDataException();
                }
                var key = editedLine[0].Trim();
                var value = editedLine[1].Trim();

                if (string.IsNullOrWhiteSpace(key))
                {
                    throw new InvalidDataException();
                }

                if (_settings.ContainsKey(key))
                {
                    throw new InvalidDataException();
                }
                _settings.Add(key, value);
            }
        }

        public T GetSetting<T>(string key) // получаем настройку и преобразуем из стринг в другой тип
        {
            string value = _settings[key];

            try
            {
                return (T)Convert.ChangeType(value, typeof(T)); // определяем, если преобразование ок
            }
            catch (Exception ex)
            {
                throw new InvalidDataException(
                    $"Значение ключа '{key}' невозможно преобразовать в тип {typeof(T).Name}.",
                    ex);
            }
        }
    }
}

