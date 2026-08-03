using System;

namespace MiniAutomationToolkit.Core.Models
{
    // задание 3.4
    public record UserDto
    {
        public string Name { get; }
        public string Email { get; }

        public UserDto(string name, string email)
        {

            if (string.IsNullOrWhiteSpace(name))

            {

                throw new ArgumentException(); // имя не должно быть пустым, иначе ошибка

            }
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || email.Contains(" "))
            {

                throw new ArgumentException($"Invalid email: {email}"); // email не должно быть пустым,  должен содержать символ @, не должно быть пробелов
            }

            Name = name;
            Email = email;
        }
    }
}