using System;
using ElGatoAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ElGatoAPI.Services
{
	public class BreedsService
	{

        private readonly IMongoCollection<Breed> _breedCollection;


        public BreedsService(
            IOptions<CatDatabaseSettings> catDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                catDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                catDatabaseSettings.Value.DatabaseName);

            _breedCollection = mongoDatabase.GetCollection<Breed>(
                catDatabaseSettings.Value.BreedsCollectionName);
        }


        
        public async Task<List<Breed>> GetAsync() =>
            await _breedCollection.Find(_ => true).ToListAsync();

        public async Task<Breed?> GetAsync(string id) =>
            await _breedCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Breed newBreed) =>
            await _breedCollection.InsertOneAsync(newBreed);

        public async Task UpdateAsync(string id, Breed updatedBreed) =>
            await _breedCollection.ReplaceOneAsync(x => x.Id == id, updatedBreed);

        public async Task RemoveAsync(string id) =>
            await _breedCollection.DeleteOneAsync(x => x.Id == id);
    }
}

