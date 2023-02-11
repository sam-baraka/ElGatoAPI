using System;
using Newtonsoft.Json;


namespace ElGatoAPI.Models
{
	public class RemoteBreed
	{
        [JsonProperty("id")]
        public String? Id { get; set; }
        [JsonProperty("name")]
        public String? BreedName { get; set; }
        [JsonProperty("description")]
        public String? BreedDescription { get; set; }
        [JsonProperty("wikipedia_url")]
        public String? WikipediaUrl { get; set; }

    }

  
}

