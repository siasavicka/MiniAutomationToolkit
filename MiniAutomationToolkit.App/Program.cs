
using MiniAutomationToolkit.Core.Models;
using MiniAutomationToolkit.Core.Services;
using MiniAutomationToolkit.Core.Helpers;

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