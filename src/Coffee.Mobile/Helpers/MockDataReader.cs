using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Coffee.Mobile.Helpers
{
    public static class MockDataReader
    {

        public static List<string> GetAllJsons()
        {
            var assembly = typeof(MockDataReader).GetTypeInfo().Assembly;
            return assembly.GetManifestResourceNames().ToList();
        }

        public static async Task<T> GetDataFromJsonFile<T>(string jsonFileName) where T : new()
        {
            var assembly = typeof(MockDataReader).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream($"Coffee.Mobile.MockData.{jsonFileName}");

            if (stream == null)
            {
                throw new InvalidOperationException($"Unable to load required mock data file {jsonFileName} not found.");
            }

            using var reader = new StreamReader(stream, Encoding.UTF8);
            var json = await reader.ReadToEndAsync();
            var response = JsonConvert.DeserializeObject<T>(json);

            return response;
        }
    }
}
