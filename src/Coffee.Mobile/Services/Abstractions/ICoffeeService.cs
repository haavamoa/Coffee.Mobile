using System.Collections.Generic;
using System.Threading.Tasks;
using Coffee.Mobile.Models;

namespace Coffee.Mobile.Services.Abstractions {
    public interface ICoffeeService
    {
        Task<List<string>> GetAvailableMethods();

        Task<Method> GetMethod(string methodName);
    }
}