using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCurrenciesExchange.Domain.Entities
{
    public class Sentiment
    {
        public string currency { get; set; }
        public List<DateTime> timestamps { get; set; }
        public List<string> prices { get; set; }

    }
}
