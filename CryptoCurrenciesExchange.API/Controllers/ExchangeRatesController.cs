using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoCurrenciesExchange.Domain.Entities;
using CryptoCurrenciesExchange.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCurrenciesExchange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {


        private IExchangeRateService _service;
        public ExchangeRatesController(IExchangeRateService exchangeRateService)
        {
            _service = exchangeRateService;
        }
        
        
        
        [HttpGet]
        [EnableCors("general")]
        public List<ExchangeRate> Get(string trade, string to)
        {
            return _service.GetRates(trade, to);
        }

        
    }
}
