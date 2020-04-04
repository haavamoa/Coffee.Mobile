using Newtonsoft.Json;

#nullable disable
namespace Coffee.Mobile.Models {
    public partial class Recipe
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("introduction")]
        public string Introduction { get; set; }

        [JsonProperty("grind")]
        public string Grind { get; set; }

        [JsonProperty("coffee")]
        public long Coffee { get; set; }

        [JsonProperty("water")]
        public long Water { get; set; }

        [JsonProperty("bloom")]
        public long Bloom { get; set; }

        [JsonProperty("instructions")]
        public string Instructions { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }
    }
}