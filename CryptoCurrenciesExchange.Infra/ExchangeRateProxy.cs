using CryptoCurrenciesExchange.Domain.Entities;
using CryptoCurrenciesExchange.Infra.DTO;
using CryptoCurrenciesExchange.Infra.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoCurrenciesExchange.Infra
{
    public class ExchangeRateProxy : IExchangeRateProxy
    {

        // Parametrized Ids from Exchanges, can be stored in database
        private List<int> GetExchangeIds()
        {
            return new List<int> { 5, 483, 493, 174, 170, 561 };
        }

        public DTOExchangeRate GetExchangeRate(int exchangeId)
        {
            var client = new RestClient($"https://api.coinlore.net/api/exchange/?id={exchangeId}");


            var request = new RestRequest();

            var result = client.Get<DTOExchangeRate>(request);
            var obj = result.Data;

            return obj;
        }


        public List<ExchangeRate> GetRates(string trade, string to)
        {
            var ids = GetExchangeIds();
            var result = new List<ExchangeRate>();

            trade = trade.ToUpper();
            to = to.ToUpper();

            foreach (var id in ids)
            {
                var dtoRate = GetExchangeRate(id);
                var rate = new ExchangeRate
                {
                    Exchange = dtoRate._0.name,
                    Rate = dtoRate.pairs.Where(p => p._base == trade && p.quote == to)?.FirstOrDefault()?.price,
                    PriceUSD = dtoRate.pairs.Where(p => p._base == trade && p.quote == to)?.FirstOrDefault()?.price_usd,
                    RequestTime = GetDateFomUnix(dtoRate.pairs.Where(p => p._base == trade && p.quote == to)?.FirstOrDefault()?.time)
                };
                result.Add(rate);
            }

            if (result.Any())
            {
                var bestPrice = result.Where(r => r.PriceUSD == result.Min(p => p.PriceUSD)).FirstOrDefault();
                if (bestPrice != null)
                {
                    bestPrice.BestPrice = true;
                }
            }

            return result.Where(e => e.Rate != null).ToList();
        }

        private DateTime GetDateFomUnix(int? unixTimeStamp)
        {
            int time = 0;
            time = unixTimeStamp.HasValue ? unixTimeStamp.Value : 0;

            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(time).ToLocalTime();
            return dtDateTime;
        }
    }
}
