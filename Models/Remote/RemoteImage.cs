using System;
using Newtonsoft.Json;


namespace ElGatoAPI.Models
{ 
    public class RemoteImage
    {
        [JsonProperty("id")]
        public String? Id { get; set; }
        [JsonProperty("url")]
        public String? Url { get; set; }
        [JsonProperty("width")]
        public int? Width { get; set; }
        [JsonProperty("height")]
        public int? Height { get; set; }
        [JsonProperty("breeds")]
        public List<RemoteBreed>? Breeds { get; set; }
    }
}