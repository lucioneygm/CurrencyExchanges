using CryptoCurrenciesExchange.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCurrenciesExchange.Domain.Interfaces.Repositories
{
    public interface ISentimentRepository
    {
        List<Sentiment> GetData(string trade, string to);
    }
}
