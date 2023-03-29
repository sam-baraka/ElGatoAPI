using System;
namespace ElGatoAPI.Models
{
    public class CatDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string BreedsCollectionName { get; set; } = null!;

        public string ImagesCollectionName { get; set; } = null!;

        public string PostsCollectionName { get; set; } = null!;
    }
}

