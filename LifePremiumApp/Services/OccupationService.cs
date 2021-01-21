using LifePremiumApp.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LifePremiumApp.Services
{
    public class OccupationService : IOccupationService
    {
        private HttpClient _client;
        private IHttpDataService _httpDataService;

        public OccupationService( IHttpDataService httpDataService)
        {
            _httpDataService = httpDataService;
        }
        public async  Task<IEnumerable<Occupation>> GetOccupations()
        {
            var resp = await _httpDataService.GetDataAsync<Occupation>("Occupation");
        
            return resp; 
        }
    }
}
