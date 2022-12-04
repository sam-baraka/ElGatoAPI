using System;
using Newtonsoft.Json;


namespace ElGatoAPI.Models.Remote
{
	public class RemoteBreed
	{
        [JsonProperty("id")]
        public String? Id { get; set; }
        [JsonProperty("name")]
        String? BreedName { get; set; }
        [JsonProperty("description")]
        String? BreedDescription { get; set; }
        [JsonProperty("wikipedia_url")]
        String? WikipediaUrl { get; set; }
        [JsonProperty("image")]
        BreedImage? BreedImage { get; set; }

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

