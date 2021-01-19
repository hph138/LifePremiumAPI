using LifePremiumAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LifePremiumAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FactorController : ControllerBase
    {
        private readonly ApiContext _apiContext;
        public FactorController(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        // GET api/values  
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Factor> factors = _apiContext.GetFactors();
            return Ok(factors);
        }
    }
}
