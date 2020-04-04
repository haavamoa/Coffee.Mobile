using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Coffee.Mobile.Models
{
    public partial class Method
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("img")]
        public Uri Img { get; set; }

        [JsonProperty("recipes")]
        public Recipe[] Recipes { get; set; }
    }

    public partial class Method
    {
        public static Method FromJson(string json) => JsonConvert.DeserializeObject<Method>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Method self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
