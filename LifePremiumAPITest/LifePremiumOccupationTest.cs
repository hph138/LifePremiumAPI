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

namespace LifePremiumAPITest
{

    public class LifePremiumOccupationTest 
    {
        private readonly HttpClient client;
        public LifePremiumOccupationTest()
        {
            var server = new TestServer(new WebHostBuilder()
                    .UseEnvironment("Development")
                    .UseTestServer()
                    .UseStartup<Startup>());
            client = server.CreateClient();
        }

        [Fact]
         public async Task GetOccupationAsync ()
        {

            var request = new HttpRequestMessage(new HttpMethod("GET"), "/Occupation/");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
           
        }

       [Fact]
        public async Task GetOccupationDataAsync()
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/Occupation/");
            var response = client.GetAsync(request.RequestUri.ToString()).Result;
            string responseBody = await response.Content.ReadAsStringAsync();
            JArray textArray = JArray.Parse(responseBody);
            Assert.Equal(6, textArray.Count);
        }
    }
}
