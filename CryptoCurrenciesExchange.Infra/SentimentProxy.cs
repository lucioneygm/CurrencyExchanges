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
    public class SentimentProxy : ISentimentProxy
    {

        protected string _key = "cacbbc830e062ce26141cbd999b15df1";

        public List<Sentiment> GetData(string trade, string to)
        {
            var client = new RestClient($"https://api.nomics.com/v1/currencies/sparkline?key={_key}");

            var request = new RestRequest();
            request.AddQueryParameter("ids", $"{trade},{to}");
            request.AddQueryParameter("start", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd'T'HH:mm:ssZ"));            

            var timeline = client.Get<List<Sentiment>>(request);
            var obj = timeline.Data;

            return obj;
        }
    }
}
