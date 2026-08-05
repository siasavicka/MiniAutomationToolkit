using System;

// задание 4.7

namespace MiniAutomationToolkit.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool HasHttpScheme(this string? input)
        {
            if (string.IsNullOrWhiteSpace(input)) // завершаем метод, если строка null, пустая, пробел
            {
                return false;
            }
            // сравниваем протоколы без учёта регистра
            var httpSchemeResult = input.StartsWith("http://", StringComparison.OrdinalIgnoreCase);
            var httpsSchemeResult = input.StartsWith("https://", StringComparison.OrdinalIgnoreCase);
            var schemeResult = httpSchemeResult || httpsSchemeResult;

            return schemeResult;
        }
    }
}