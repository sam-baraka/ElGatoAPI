using System;
using ElGatoAPI.Models;
using Microsoft.Extensions.Options;
using RestSharp;

namespace ElGatoAPI.Services.APIService
{
	public class ApiService
	{
        private readonly RestClient? _restClient;
        IOptions<CatApiSettings>? catApiSettings;
        // Global method to get data from the API
        public string? Get(string path)
        {
            var request = new RestRequest(catApiSettings!.Value.BaseUrl + path, Method.Get);
            var response = _restClient!.Execute(request);
            return response.Content;

        }
        // Global method to post data to the API
        public string? Post(string path, object data)
        {
            var request = new RestRequest(catApiSettings!.Value.BaseUrl + path, Method.Post);
            request.AddJsonBody(data);
            var response = _restClient!.Execute(request);
            return response.Content;
        }

    }
}


