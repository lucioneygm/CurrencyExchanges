using CryptoCurrenciesExchange.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class APICallsTest
    {
        [TestMethod]
        public void ProxyTestBTC_USDT()
        {
            var proxy = new ExchangeRateProxy();

            var rates = proxy.GetRates("BTC", "USDT");

            Assert.AreEqual(true, rates.Any());
        }

        [TestMethod]
        public void ProxyTestETH_USDT()
        {
            var proxy = new ExchangeRateProxy();

            var rates = proxy.GetRates("ETH", "BTC");

            Assert.AreEqual(true, rates.Any());
        }

        [TestMethod]
        public void ProxyTestXMR_USDT()
        {
            var proxy = new ExchangeRateProxy();

            var rates = proxy.GetRates("XMR", "BTC");

            Assert.AreEqual(true, rates.Any());
        }

        [TestMethod]
        public void ProxyTestZEC_USDT()
        {
            var proxy = new ExchangeRateProxy();

            var rates = proxy.GetRates("ZEC", "BTC");

            Assert.AreEqual(true, rates.Any());
        }

        [TestMethod]
        public void ProxyTestBCH_USDT()
        {
            var proxy = new ExchangeRateProxy();

            var rates = proxy.GetRates("BCH", "BTC");

            Assert.AreEqual(true, rates.Any());
        }

        [TestMethod]
        public void SentimentTest()
        {
            var proxy = new SentimentProxy();
            
            var data = proxy.GetData("BTC","USDT");

            Assert.AreEqual(true, data.Any());
        }
    }
}
