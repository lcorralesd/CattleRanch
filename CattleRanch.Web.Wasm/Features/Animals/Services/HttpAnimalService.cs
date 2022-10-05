using CattleRanch.Web.Wasm.Features.Animals.Models;
using System.Net.Http;
using System.Text.Json;

namespace CattleRanch.Web.Wasm.Features.Animals.Services;

public class HttpAnimalService : IHttpAnimalService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly JsonSerializerOptions _options = new() { PropertyNameCaseInsensitive = true };

    public HttpAnimalService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

    public async Task<IReadOnlyList<AnimalModel>> GetAnimals()
    {
        var client = _httpClientFactory.CreateClient("CattleRanchAPI");
        var response = await client.GetAsync("api/animals");
        var content = await response.Content.ReadAsStringAsync();

        if(!response.IsSuccessStatusCode)
        {
            throw new Exception("Error en la petición HTTP");
        }
        IReadOnlyList<AnimalModel> result = JsonSerializer.Deserialize<IReadOnlyList<AnimalModel>>(content, _options)!;

        return result;
    }
}
