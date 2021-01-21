using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LifePremiumApp.Data;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

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

    }
}
