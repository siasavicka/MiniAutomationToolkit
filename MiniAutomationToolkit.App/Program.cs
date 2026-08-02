
using MiniAutomationToolkit.Core.Models;
using MiniAutomationToolkit.Core.Services;

Console.WriteLine("MiniAutomationToolkit started.");
DisplayDiscount(500m, ClientType.Vip);
DisplayDiscount(2000m, ClientType.Vip);
DisplayDiscount(800m, ClientType.Premium);
DisplayDiscount(1000m, ClientType.Premium);
DisplayDiscount(1500m, ClientType.Premium);
DisplayDiscount(500m, ClientType.Regular);
DisplayDiscount(1500m, ClientType.Regular);
DisplayDiscount(1000m, ClientType.Regular);

void DisplayDiscount(decimal orderAmount, ClientType clientType)
{
    var discount = DiscountCalculator.CalculateDiscount(orderAmount, clientType);
    Console.WriteLine($"Client: {clientType}, amount: {orderAmount}, discount: {discount:0.##}");
}