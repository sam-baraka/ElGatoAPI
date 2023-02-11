using System;
using ElGatoAPI.Models;
using Microsoft.Extensions.Options;
using RestSharp;

namespace ElGatoAPI.Services;

class ApiService
{
    static RestClient client = new RestClient("https://api.thecatapi.com/v1/");
    public static async Task<String> GetData(String path)
    {
        var request = new RestRequest(path,Method.Get);
        var response = await client.ExecuteAsync(request);
        return response.Content!;
    }
}


