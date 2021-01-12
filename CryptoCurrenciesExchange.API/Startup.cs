using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoCurrenciesExchange.Domain.Interfaces.Repositories;
using CryptoCurrenciesExchange.Domain.Interfaces.Services;
using CryptoCurrenciesExchange.Domain.Service;
using CryptoCurrenciesExchange.Infra;
using CryptoCurrenciesExchange.Infra.Interfaces;
using CryptoCurrenciesExchange.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CryptoCurrenciesExchange.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options =>
            {
                options.AddPolicy("general",
                builder =>
                {
                    builder.WithOrigins("*");
                });
            });

            services.AddTransient<IExchangeRateService, ExchangeRateService>();
            services.AddTransient<IExchangeRateRepository, ExchangeRateRepository>();
            services.AddTransient<IExchangeRateProxy, ExchangeRateProxy>();

            services.AddTransient<ISentimentService, SentimentService>();
            services.AddTransient<ISentimentRepository, SentimentRepository>();
            services.AddTransient<ISentimentProxy, SentimentProxy>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
