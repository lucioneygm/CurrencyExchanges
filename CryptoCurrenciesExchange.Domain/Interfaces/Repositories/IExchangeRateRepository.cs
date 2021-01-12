using CryptoCurrenciesExchange.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCurrenciesExchange.Domain.Interfaces.Repositories
{
    public interface IExchangeRateRepository
    {
        List<ExchangeRate> GetRates(string trade, string to);
    }
}
