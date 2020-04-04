using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Coffee.Mobile.Helpers;
using Coffee.Mobile.Models;
using Coffee.Mobile.Services.Abstractions;

namespace Coffee.Mobile.Services
{
    public class CoffeeService : ICoffeeService
    {
        public Task<List<string>> GetAvailableMethods()
        {
            return Task.FromResult(new List<string>(){"V60.json", "V60.json", "V60.json", "V60.json"});
        }

        public Task<Method> GetMethod(string methodName)
        {
            return MockDataReader.GetDataFromJsonFile<Method>(methodName);
        }
    }
}