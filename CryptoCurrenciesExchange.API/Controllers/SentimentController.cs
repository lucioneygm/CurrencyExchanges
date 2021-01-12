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
    public class SentimentController : ControllerBase
    {
        protected ISentimentService _service;

        public SentimentController(ISentimentService sentimentService)
        {
            _service = sentimentService;
        }

        [HttpGet]
        [EnableCors("general")]
        public List<Sentiment> Get(string trade, string to)
        {
            return _service.GetData(trade, to);
        }
    }
}