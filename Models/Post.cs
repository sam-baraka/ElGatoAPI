using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ElGatoAPI.Models
{
	public class Post
	{
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string? Id { get; set; } = null!;
            [BsonElement("Title")]
            public string Title { get; set; } = null!;
            [BsonElement("Content")]
            public string Content { get; set; } = null!;
            [BsonElement("Author")]
            public string Author { get; set; } = null!;
            [BsonElement("Date")]
            public string Date { get; set; } = null!;
            [BsonElement("Image")]
            public string Image { get; set; } = null!;
        
    }
}

