using LifePremiumApp.Data;
using System;
using System.Collections.Generic;
using LifePremiumApp.Model;
using System.Threading.Tasks;

namespace LifePremiumApp.Services
{
   public  interface ICalculatePremium
    {
     Task<decimal> GetPremium(CalculateModel model);
    }
}
