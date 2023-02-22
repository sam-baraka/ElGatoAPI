using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElGatoAPI.Models
{
	public class Breed
	{
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string? Id { get; set; } = null!;

            [BsonElement("Name")]
            public string BreedName { get; set; } = null!;
            [BsonElement("Description")]
            public string BreedDescription { get; set; } = null!;
            [BsonElement("WikipediaUrl")]
            public string? WikipediaUrl { get; set; } = null!;
            [BsonElement("CFAUrl")]
            public string? CFAUrl { get; set; } = null!;
            [BsonElement("VetstreetUrl")]
            public string? VetstreetUrl { get; set; } = null!;
            [BsonElement("VCAHospitalsUrl")]
            public string? VCAHospitalsUrl { get; set; } = null!;
            [BsonElement("Origin")]
            public string? Origin { get; set; } = null!;
            [BsonElement("Temperament")]
            public string? Temperament { get; set; } = null!;
            [BsonElement("LifeSpan")]
            public string? LifeSpan { get; set; } = null!;
            [BsonElement("Indoor")]
            public int? Indoor { get; set; } = null!;
            [BsonElement("Lap")]
            public int? Lap { get; set; } = null!;
            [BsonElement("CountryCode")]
            public string? CountryCode { get; set; } = null!;
            [BsonElement("CountryCodes")]
            public string? CountryCodes { get; set; } = null!;

        
    }
}

