using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using SampleAPp.models;

namespace SampleAPp.Controllers;


[ApiController]
[Route("[controller]")]

public class User : ControllerBase
{

    private readonly IHttpClientFactory _httpClientFactory;

    private readonly ILogger<User> _logger;

    public User(ILogger<User> logger, IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }


    [HttpGet]
    public async Task<string> Get()
    {
        var httpClient = _httpClientFactory.CreateClient();
        var url = $"https://jsonplaceholder.typicode.com/users";
        var response = await httpClient.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }


    [HttpGet("{id}/Albums")]
    public async Task<string> newAlbum(int id)
    {

        var httpClient = _httpClientFactory.CreateClient();
        var url2 = $"https://jsonplaceholder.typicode.com/albums?userId={id}";
        var response = await httpClient.GetAsync(url2);
        return await response.Content.ReadAsStringAsync();

    }


    [HttpGet("albums/{id}/photos")]
    public async Task<string> photos(int id)
    {
        var photosClient = _httpClientFactory.CreateClient();
        var photosURL = $"https://jsonplaceholder.typicode.com/albums/{id}/photos";
        var response = await photosClient.GetAsync(photosURL);
        return await response.Content.ReadAsStringAsync();
    }

    

    [HttpGet("albums/{id}/photos/firstPhoto")]
    public async Task<string[]> firstPhoto(int id)
    {
        string[] arr = new string[10];
        var firstPhotosClient = _httpClientFactory.CreateClient();
        var firstPhotoUrl = "";
        for (id = 0; id < 10; id++)
        {
            int num = (id - 1) * 50 + 1;
            firstPhotoUrl = $"https://jsonplaceholder.typicode.com/albums/{id}/photos?id={num}";
            var response = await firstPhotosClient.GetAsync(firstPhotoUrl);
            var albumPhoto  = await response.Content.ReadFromJsonAsync<Photos[]>();
            
        }

        return arr;
    }
    
    
    
    
    
    
    


}


