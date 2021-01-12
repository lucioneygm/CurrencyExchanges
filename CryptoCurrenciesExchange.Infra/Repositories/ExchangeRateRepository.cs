using CryptoCurrenciesExchange.Domain.Entities;
using CryptoCurrenciesExchange.Domain.Interfaces.Repositories;
using CryptoCurrenciesExchange.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCurrenciesExchange.Infra.Repositories
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        protected IExchangeRateProxy _proxy;

        public ExchangeRateRepository(IExchangeRateProxy exchangeRateProxy)
        {
            _proxy = exchangeRateProxy;
        }

        public List<ExchangeRate> GetRates(string trade, string to)
        {
            return _proxy.GetRates(trade, to);
        }
    }
}
