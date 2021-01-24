using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LifePremiumApp.Data;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LifePremiumApp.Services
{
    public class HttpDataService : IHttpDataService
    {
        private HttpClient _client;

        public HttpDataService(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<IEnumerable<T>> GetDataAsync<T>(string controller)
        {
            IEnumerable<T> response = await _client.GetJsonAsync<IList<T>>(controller);
            return response;
        }

        public async Task<string> GetDataPostAsync(string controller, dynamic obj)
        {
            try
            {
                HttpResponseMessage httpResponseMessage = null;
                var request = new HttpRequestMessage(new HttpMethod("POST"), $"/{controller}/");
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var httpContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                httpResponseMessage = _client.PostAsync($"/{controller}/", httpContent).GetAwaiter().GetResult();
                httpResponseMessage.EnsureSuccessStatusCode();
                return await httpResponseMessage.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
