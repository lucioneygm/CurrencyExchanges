using CryptoCurrenciesExchange.Domain.Entities;
using CryptoCurrenciesExchange.Domain.Interfaces.Repositories;
using CryptoCurrenciesExchange.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCurrenciesExchange.Domain.Service
{
    public class ExchangeRateService : IExchangeRateService
    {
        protected IExchangeRateRepository _repository;
        public ExchangeRateService(IExchangeRateRepository exchangeRateService)
        {
            _repository = exchangeRateService;
        }
        public List<ExchangeRate> GetRates(string trade, string to)
        {
            return _repository.GetRates(trade, to);
        }
    }
}
