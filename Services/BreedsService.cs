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
        public async Task FetchAndStoreBreeds() {
            TheCatApiService theCatApiService = new TheCatApiService();
            List<RemoteBreed>? breeds = await theCatApiService.GetBreeds();
            if (breeds is not null)
            {
                foreach (var breed in breeds)
                {
                    Breed newBreed = new()
                    {
                        BreedName = breed.BreedName!,
                        BreedDescription = breed.BreedDescription!,
                        Origin = breed.Origin!,
                        Temperament = breed.Temperament!,
                        LifeSpan = breed.LifeSpan!,
                        Indoor = breed.Indoor!,
                        Lap = breed.Lap!,
                        CountryCode = breed.CountryCode!,
                        CountryCodes = breed.CountryCodes!,
                        WikipediaUrl = breed.WikipediaUrl!,
                        VetstreetUrl = breed.VetstreetUrl!,
                        VCAHospitalsUrl = breed.VCAHospitalsUrl!,
                    };
                    // Add if not exists
                    if (await GetAsyncWithName(breed.BreedName!) is null)
                    {
                        await CreateAsync(newBreed);
                    }
                }
            }
        }
        public async Task<List<Breed>> GetAsync() {

            var breeds=await _breedCollection.Find(_ => true).ToListAsync();
            if (breeds.Count < 5)
            {
               await FetchAndStoreBreeds();
            }
            return breeds;
    }
        public async Task<Breed?> GetAsync(string id) =>
            await _breedCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Breed?> GetAsyncWithName(string name) =>
            await _breedCollection.Find(x => x.BreedName == name).FirstOrDefaultAsync();

        public async Task CreateAsync(Breed newBreed) =>
            await _breedCollection.InsertOneAsync(newBreed);

        public async Task UpdateAsync(string id, Breed updatedBreed) =>
            await _breedCollection.ReplaceOneAsync(x => x.Id == id, updatedBreed);

        public async Task RemoveAsync(string id) =>
            await _breedCollection.DeleteOneAsync(x => x.Id == id);
    }
}

