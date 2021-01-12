using CryptoCurrenciesExchange.Domain.Entities;
using CryptoCurrenciesExchange.Domain.Interfaces.Repositories;
using CryptoCurrenciesExchange.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCurrenciesExchange.Domain.Service
{
    public class SentimentService : ISentimentService
    {
        protected ISentimentRepository _repository;

        public SentimentService(ISentimentRepository sentimentRepository)
        {
            _repository = sentimentRepository;
        }

        public List<Sentiment> GetData(string trade, string to)
        {
            return _repository.GetData(trade, to);
        }
    }
}
