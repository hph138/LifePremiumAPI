using LifePremiumApp.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace LifePremiumApp.Services
{
    public class FactorService : IFactorService
    {
        private IHttpDataService _dataService;

        public FactorService(IHttpDataService httpDataService)
        {
            _dataService = httpDataService;
        }

        
        public Task<IEnumerable<Factor>> GetFactors()
        {
            throw new NotImplementedException();
        }
    }
}
