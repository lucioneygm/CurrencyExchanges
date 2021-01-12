using CryptoCurrenciesExchange.Domain.Entities;
using CryptoCurrenciesExchange.Domain.Interfaces.Repositories;
using CryptoCurrenciesExchange.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCurrenciesExchange.Infra.Repositories
{
    public class SentimentRepository : ISentimentRepository
    {
        protected ISentimentProxy _proxy;
        public SentimentRepository(ISentimentProxy sentimentProxy)
        {
            _proxy = sentimentProxy;
        }

        public List<Sentiment> GetData(string trade, string to)
        {
            return _proxy.GetData(trade, to);
        }
    }
}
