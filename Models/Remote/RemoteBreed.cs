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
        [JsonProperty("image")]
        public BreedImage? BreedImage { get; set; }

    }

    public class BreedImage
    {
        [JsonProperty("id")]
        public String? Id { get; set; }
        [JsonProperty("height")]
        public int? ImageHeight { get; set; }
        [JsonProperty("width")]
        public int? ImageWidth { get; set; }
        [JsonProperty("url")]
        public String? ImageUrl { get; set; }

    }
}

