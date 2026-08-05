
using MiniAutomationToolkit.Core.Configuration;
using MiniAutomationToolkit.Core.Extensions;
using MiniAutomationToolkit.Core.Helpers;
using MiniAutomationToolkit.Core.Models;
using MiniAutomationToolkit.Core.Pages;
using MiniAutomationToolkit.Core.Services;

//задание 2.2

Console.WriteLine("MiniAutomationToolkit started.");
DisplayDiscount(500m, ClientType.Vip);
DisplayDiscount(2000m, ClientType.Vip);
DisplayDiscount(800m, ClientType.Premium);
DisplayDiscount(1000m, ClientType.Premium);
DisplayDiscount(1500m, ClientType.Premium);
DisplayDiscount(500m, ClientType.Regular);
DisplayDiscount(1500m, ClientType.Regular);
DisplayDiscount(1000m, ClientType.Regular);

//задание 2.3

List<string> fileNames = new List<string>()
    {
    "error_2024.log",
    "debug.txt",
    "screen_001.png",
    "application.log",
    "notes.txt",
    "screen_final.PNG",
    "trace_01.log",
    "readme.txt",
    "screen_002.PnG",
    "server_error.log",
    "config.txt",
    "audit.log",
    "screen_003.png",
    "results.txt",
    "warning.log",
    "todo.txt",
    "screen_login.PNG",
    "performance.log",
    "summary.txt",
    "crash_2025.log"
};
var firstScreenshot = FileSearcher.FindFirstScreenshot(fileNames); //вызываем метод, который найдет первое имя с расширением .png
Console.WriteLine($"First screenshot: {firstScreenshot}");


try
{
    List<string> fileNamesWithoutScreenshots = new List<string>()
{   "error_2025.log",
    "debug.txt",
    "application.log",
    "notes.txt",
    "trace.log",
    "readme.txt",
    "server_error.log",
    "config.txt"
};
    var firstFileNameWithoutScreenshot = FileSearcher.FindFirstScreenshot(fileNamesWithoutScreenshots); // вызвали метод для проверки на совпадение


}
catch (FileNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}


// задание 2.2
void DisplayDiscount(decimal orderAmount, ClientType clientType)
{
    var discount = DiscountCalculator.CalculateDiscount(orderAmount, clientType);
    Console.WriteLine($"Client: {clientType}, amount: {orderAmount}, discount: {discount:0.##}");
}

// задание 3.4

UserDto userDto1 = new UserDto("Alex Smith", "alex@example.com"); // успешное создание пользователя 
Console.WriteLine($"{userDto1}");

UserDto userDto2 = new UserDto("Alex Smith", "alex@example.com"); // равенство двух объектов с одинаковыми значениями
var result2 = userDto2.Equals(userDto1);
Console.WriteLine($"Users are equal - {result2}");

// userDto1.Name = "alex smith"; - невозможность изменить свойства уже созданного объекта.

void TryCreateUser(string name, string email) // метод для шибочных сценариев, которые не должны завершать работу приложения
{
    try
    {
        new UserDto(name, email);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

TryCreateUser("", "alex@email.com"); //пустое имя + корректный email;
TryCreateUser("Alex", ""); //корректное имя + пустой email;                           
TryCreateUser("Alex", "alex.email.com"); //корректное имя + email без @;
TryCreateUser("Alexx", "alex@email.com "); //корректное имя + email с пробелом.


// задание 3.5

List<BasePage> pages = new List<BasePage>()
{
    new HomePage(),
    new LoginPage()
};

foreach (BasePage page in pages)
{
    page.Load();
}

var urls = pages.Select(page => page.Url);// достаем все урл из коллекции
var uniqueUrls = urls.Distinct(); //выбираем уникальные
if (uniqueUrls.Count() == pages.Count) // и сравниваем количество между собой
{
    Console.WriteLine("All page URLs are unique.");
}
else throw new InvalidOperationException();


// задание 4.6

var filePath = @"MiniAutomationToolkit.App\data\appsettings.txt";
AppConfig appConfig = new AppConfig(filePath);


var resultUrl = appConfig.GetSetting<string>("baseUrl"); // проверки по заданию
Console.WriteLine($"{resultUrl}");


var resultTimeout = appConfig.GetSetting<int>("timeout");
Console.WriteLine($"{resultTimeout}");


var resultRetryCount = appConfig.GetSetting<int>("retryCount");
Console.WriteLine($"{resultRetryCount}");


var resultHeadless = appConfig.GetSetting<bool>("headless");
Console.WriteLine($"{resultHeadless}");

try
{
    var resultWrongKey = appConfig.GetSetting<bool>("run");
    Console.WriteLine($"{resultWrongKey}");
}
catch (KeyNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    var resultWrongType = appConfig.GetSetting<int>("headless");
    Console.WriteLine($"{resultWrongType}");
}
catch (InvalidDataException ex)
{
    Console.WriteLine(ex.Message);
}


// задание 4.7

var webs = new List<string?>()
{
"https://google.com",      //→ true
"http://example.org",      //→ true
"ftp://files.example.com", //→ false
 null,                     //→ false
"HTTPS://SITE.EXAMPLE.COM" //→ true
};

foreach (var web in webs)
{
    var result = web.HasHttpScheme();
    Console.WriteLine($"{web} -> {result}");


}