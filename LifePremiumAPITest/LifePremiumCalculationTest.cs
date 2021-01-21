using LifePremiumAPI;

using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

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

        struct PayLoad
        {
            public int Age;
            public decimal Amount;
            public int RateId;
        }

        [Fact]
        public async Task GetCalculationPostAsync()
        {
            HttpResponseMessage HttpResponseMessage = null;
            var request = new HttpRequestMessage(new HttpMethod("POST"), "/Calculations/");
          
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            PayLoad payLoad = new PayLoad();
            payLoad.Age = 50;
            payLoad.Amount = 10000;
            payLoad.RateId = 1;

            var httpContent = new StringContent(JsonConvert.SerializeObject(payLoad), Encoding.UTF8, "application/json");
            HttpResponseMessage = await client.PostAsync("/Calculations/", httpContent);
            var calc = JObject.Parse(HttpResponseMessage.Content.ReadAsStringAsync().Result);
            Assert.Equal("6000", calc["premium"].ToString());
        }

    }


}
