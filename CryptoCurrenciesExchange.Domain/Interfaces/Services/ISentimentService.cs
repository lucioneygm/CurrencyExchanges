using CryptoCurrenciesExchange.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCurrenciesExchange.Domain.Interfaces.Services
{
    public interface ISentimentService
    {
        List<Sentiment> GetData(string trade, string to);
    }
}
