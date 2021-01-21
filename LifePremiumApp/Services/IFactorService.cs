using LifePremiumApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePremiumApp.Services
{
    public interface IFactorService
    {
        Task<IEnumerable<Factor>> GetFactors();
    }
}
