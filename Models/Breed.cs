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
            [BsonElement("Image")]
            public string BreedImage { get; set; } = null!;
        
    }
}

