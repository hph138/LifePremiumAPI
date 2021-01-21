using LifePremiumApp.Data;
using System;
using System.Collections.Generic;
using LifePremiumApp.Model;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LifePremiumApp.Services
{
    public class CalculatePremiumService : ICalculatePremium
    {
        private IHttpDataService _httpDataService;

        public CalculatePremiumService(IHttpDataService httpDataService)
        {
            _httpDataService = httpDataService;
        }
        public  async Task<decimal> GetPremium(CalculateModel calculateModel)
        {
            string premiumJobj= await _httpDataService.GetDataPostAsync("calculations", calculateModel);
            PremiumResponse premiumResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<PremiumResponse>(premiumJobj);
           return premiumResponse.Premium;
            
        }

    }
}
