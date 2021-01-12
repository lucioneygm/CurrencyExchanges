using CryptoCurrenciesExchange.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCurrenciesExchange.Domain.Interfaces.Services
{
    public interface IExchangeRateService
    {
        List<ExchangeRate> GetRates(string trade, string to);
    }
}
