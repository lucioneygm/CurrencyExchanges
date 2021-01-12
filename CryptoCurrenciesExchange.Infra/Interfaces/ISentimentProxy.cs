using CryptoCurrenciesExchange.Domain.Entities;
using CryptoCurrenciesExchange.Infra.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCurrenciesExchange.Infra.Interfaces
{
    public interface ISentimentProxy
    {
        List<Sentiment> GetData(string trade, string to);
    }
}
