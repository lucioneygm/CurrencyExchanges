using CryptoCurrenciesExchange.Domain.Entities;
using CryptoCurrenciesExchange.Infra.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCurrenciesExchange.Infra.Interfaces
{
    
    public interface IExchangeRateProxy
    {
        List<ExchangeRate> GetRates(string trade, string to);        
    }
}
