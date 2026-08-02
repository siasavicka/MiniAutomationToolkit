using MiniAutomationToolkit.Core.Models;
using System;

namespace MiniAutomationToolkit.Core.Services;

public class DiscountCalculator

{
    public static decimal CalculateDiscount(decimal orderAmount, ClientType clientType)
    {
        if (orderAmount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(orderAmount));
        }

        var result = clientType switch
        {
            ClientType.Regular => orderAmount <= 1000 ? 0m : orderAmount * 0.05m,

            ClientType.Premium => orderAmount <= 1000 ? orderAmount * 0.05m : orderAmount * 0.1m,

            ClientType.Vip => orderAmount * 0.15m,


        };

        return result;
    }
}