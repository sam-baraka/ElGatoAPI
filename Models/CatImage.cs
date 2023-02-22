using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElGatoAPI.Models
{
	public class CatImage
	{
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string? Id { get; set; } = null!;

            [BsonElement("url")]
            public string? Url { get; set; } = null!;

            [BsonElement("height")]
            public int? Height { get; set; } = null!;
            [BsonElement("width")]

            public int? Width { get; set; } = null!;

        
    }
}

