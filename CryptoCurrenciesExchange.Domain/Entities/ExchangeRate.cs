using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCurrenciesExchange.Domain.Entities
{
    public class ExchangeRate
    {
        public string Exchange { get; set; }
        public decimal? Rate { get; set; }
        public DateTime RequestTime { get; set; }
        public bool BestPrice { get; set; }
        public decimal? PriceUSD { get; set; }
    }
}
