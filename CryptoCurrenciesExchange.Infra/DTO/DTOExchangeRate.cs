using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCurrenciesExchange.Infra.DTO
{


    public class DTOExchangeRate
    {
        public Exchange _0 { get; set; }
        public List<Pair> pairs { get; set; }
    }

    public class Exchange
    {
        public string name { get; set; }
        public string date_live { get; set; }
        public string url { get; set; }
    }

    public class Pair
    {
        public string _base { get; set; }
        public string quote { get; set; }
        public decimal volume { get; set; }
        public decimal? price { get; set; }
        public decimal? price_usd { get; set; }
        public int time { get; set; }
    }


}
