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
    }
}