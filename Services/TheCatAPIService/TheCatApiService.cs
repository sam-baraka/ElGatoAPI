using ElGatoAPI.Models;
using Newtonsoft.Json;

namespace ElGatoAPI.Services
{
    public class TheCatApiService{
        
     ApiService apiService = new ApiService();
        public async Task<List<RemoteBreed>?> GetBreeds()
        {   
            var response= await ApiService.GetData("breeds");
            var breeds = JsonConvert.DeserializeObject<List<RemoteBreed>>(response);
            return breeds;
        }

        public async Task<List<RemoteImage>?> GetImages()
        {
            var response = await ApiService.GetData("images/search");
            var images = JsonConvert.DeserializeObject<List<RemoteImage>>(response);
            return images;
        }
    }
}