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
        [JsonProperty("cfa_url")]
        public String? CFAUrl { get; set; }
        [JsonProperty("vetstreet_url")]
        public String? VetstreetUrl { get; set; }
        [JsonProperty("vcahospitals_url")]
        public String? VCAHospitalsUrl { get; set; }
        [JsonProperty("origin")]
        public String? Origin { get; set; }
        [JsonProperty("temperament")]
        public String? Temperament { get; set; }

        [JsonProperty("life_span")]
        public String? LifeSpan { get; set; }
 
        [JsonProperty("indoor")]
        public int? Indoor { get; set; }

        [JsonProperty("lap")]
        public int? Lap { get; set; }

        [JsonProperty("country_code")]
        public String? CountryCode { get; set; }

        [JsonProperty("country_codes")]

        public String? CountryCodes { get; set; }

    }

  
}

