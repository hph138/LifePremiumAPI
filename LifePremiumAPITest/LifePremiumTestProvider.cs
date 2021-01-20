using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Moq;
using LifePremiumAPI;

namespace LifePremiumAPITest
{
   public class LifePremiumTestProvider
    {
        public HttpClient client { get; private set; }
        public IServiceCollection services;
        public IServiceProvider serviceProvider;
        public LifePremiumAPI.Controllers.CalculationsController calculationsController;

        public LifePremiumTestProvider()
        {
            var mockJsRuntime = new Mock<IJSRuntime>().Object;
            services = new ServiceCollection();
            services.AddHttpClient<LifePremiumAPI.Controllers.CalculationsController>();
            serviceProvider = services.BuildServiceProvider();
        }

    }
}
