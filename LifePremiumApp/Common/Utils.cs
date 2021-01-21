using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace LifePremiumApp.Common
{
    public class Utils
    {
        public static List<string> InvalidJsonElements;
        public static IList<T> DeserializeToList<T>(string jsonString)
        {
            InvalidJsonElements = null;
            var array = JArray.Parse(jsonString);
            IList<T> objectsList = new List<T>();

            foreach (var item in array)
            {
                try
                {
                    objectsList.Add(item.ToObject<T>());
                }
                catch (Exception ex)
                {
                    InvalidJsonElements = InvalidJsonElements ?? new List<string>();
                    InvalidJsonElements.Add(item.ToString());
                }
            }

            return objectsList;
        }
    }
}
