using LifePremiumAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LifePremiumAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationsController : ControllerBase
    {
        private readonly ApiContext _apiContext;
        public CalculationsController(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }


        private async Task<decimal> GetRate(int rating, List<Factor> factors)
        {
            return factors.Where(x => x.Id.Equals(rating)).First().Point;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] JsonElement body)
        {
            List<Factor> factors = _apiContext.GetFactors();
            Calculation calculation =  System.Text.Json.JsonSerializer.Deserialize<Calculation>(System.Text.Json.JsonSerializer.Serialize(body));
            decimal rate = await GetRate(calculation.RateId,factors);

            var data = new
            {
                premium = calculation.Amount * rate * calculation.Age / 1000 * 12
            };
            return Ok(data);
        }

    }
}
