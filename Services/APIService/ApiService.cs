using System;
using ElGatoAPI.Models;
using Microsoft.Extensions.Options;
using RestSharp;

namespace ElGatoAPI.Services;

class ApiService
{
    static RestClient client = new RestClient("https://api.thecatapi.com/v1/");
    public static async Task<String> GetData(String path, Dictionary<String, String>? parameters = 
        null
    )
    {
        // Create an empty dictionary
        // var parameters = new Dictionary<String, String>();

        var request = new RestRequest(path,Method.Get);
        // Add query parameter
        if (parameters != null)
        {
            foreach (var (key, value) in parameters)
            {
                request.AddQueryParameter(key, value);
            }
        }
        request.AddHeader(name:"x-api-key",value:"015cb03c-194e-4603-a916-bdc9ce76c5d7");
        var response = await client.ExecuteAsync(request);
        return response.Content!;
    }
}


// Creae

