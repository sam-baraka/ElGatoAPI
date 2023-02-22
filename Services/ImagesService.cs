using ElGatoAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ElGatoAPI.Services
{        
    public class ImagesService
    {
        private readonly IMongoCollection<CatImage> _imagesCollection;
        public ImagesService(
            IOptions<CatDatabaseSettings> catDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                catDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                catDatabaseSettings.Value.DatabaseName);


            _imagesCollection = mongoDatabase.GetCollection<CatImage>(
                catDatabaseSettings.Value.ImagesCollectionName);
        }
         public async Task FetchAndStoreImages() {
            TheCatApiService theCatApiService = new TheCatApiService();
            List<RemoteImage>? images = await theCatApiService.GetImages();
            if (images is not null)
            {
                foreach (var image in images)
                {
                    CatImage newCatImage = new()
                    {
                        Height = image.Height,
                        Width = image.Width,
                        Url = image.Url,
                        
                    };
                    // Add if not exists
                    if (await GetAsyncWithUrl(image.Url!) is null)
                    {
                        await CreateAsync(newCatImage);
                    }
                }
            }
        }

            public async Task<List<CatImage>> GetAsync() {

            var images=await _imagesCollection.Find(_ => true).ToListAsync();
            if (images.Count < 5)
            {
               await FetchAndStoreImages();
            }
            return images;
    }
             public async Task<CatImage?> GetAsync(string id) =>
            await _imagesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

              public async Task<CatImage?> GetAsyncWithUrl(string url) =>
            await _imagesCollection.Find(x => x.Url == url).FirstOrDefaultAsync();

        public async Task CreateAsync(CatImage newCatImage) =>
            await _imagesCollection.InsertOneAsync(newCatImage);

        public async Task UpdateAsync(string id, CatImage updatedCatImage) =>
            await _imagesCollection.ReplaceOneAsync(x => x.Id == id, updatedCatImage);

        public async Task RemoveAsync(string id) =>
            await _imagesCollection.DeleteOneAsync(x => x.Id == id);
    }
}