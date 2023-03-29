using ElGatoAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ElGatoAPI.Services
{ 
   public class PostsService{
        private readonly IMongoCollection<Post> _postCollection;
        public PostsService(
            IOptions<CatDatabaseSettings> catDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                catDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                catDatabaseSettings.Value.DatabaseName);

            _postCollection = mongoDatabase.GetCollection<Post>(
                catDatabaseSettings.Value.PostsCollectionName);
        }
        public async Task<List<Post>> GetAsync() =>
            await _postCollection.Find(_ => true).ToListAsync();


        public async Task<Post> GetAsync(string id) => 
            await _postCollection.Find<Post>(post => post.Id == id).FirstOrDefaultAsync();


        public async Task<Post> CreateAsync(Post post) {
            await _postCollection.InsertOneAsync(post);
            return post;
        }

        public async Task UpdateAsync(string id, Post postIn) =>
            await _postCollection.ReplaceOneAsync(post => post.Id == id, postIn);

            public async Task RemoveAsync(Post postIn) => 
                await _postCollection.DeleteOneAsync(post => post.Id == postIn.Id);
    }


}