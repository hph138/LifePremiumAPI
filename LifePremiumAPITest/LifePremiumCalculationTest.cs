using LifePremiumAPI;
using LifePremiumAPI.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace LifePremiumAPITest
{
    public class LifePremiumCalculationTest
    {
        private readonly HttpClient client;
        public LifePremiumCalculationTest()
        {
            var server = new TestServer(new WebHostBuilder()
                    .UseEnvironment("Development")
                    .UseTestServer()
                    .UseStartup<Startup>());
            client = server.CreateClient();
        }

        [Fact]
        public async Task GetCalculationAsync()
        {

            var request = new HttpRequestMessage(new HttpMethod("GET"), "/Calculations/50/10000/1");
            var response = client.GetAsync(request.RequestUri.ToString()).Result;
            string responseBody = await response.Content.ReadAsStringAsync();

            var calc = JObject.Parse(responseBody);
            Assert.Equal("6000", calc["premium"].ToString());

        }

    }
}
