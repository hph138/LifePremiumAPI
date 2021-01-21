using System.Collections.Generic;
using System.Threading.Tasks;

namespace LifePremiumApp.Services
{
    public interface IHttpDataService
    {
       Task<IEnumerable<T>> GetDataAsync<T>(string controller);
    }
}