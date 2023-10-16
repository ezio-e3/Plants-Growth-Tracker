using System.Text.Json;

namespace DigitalGarden.WebUI;

public class GardenerHttpClient : IGardenerHttpClient
{
    private readonly HttpClient HttpClient;
    private readonly JsonSerializerOptions Options;
    public GardenerHttpClient(HttpClient client)
    {
        HttpClient = client;
        Options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};
    }

    public async Task<List<GardenerModel>> GetGardeners()
    {
        var response = await HttpClient.GetAsync("Gardener/GetAllGardeners");
        var content = await response.Content.ReadAsStringAsync();
        if(!response.IsSuccessStatusCode){
            throw new ApplicationException();
        }
        var gardeners = JsonSerializer.Deserialize<List<GardenerModel>>(content, Options);
        Console.WriteLine("EDINAM "+response.RequestMessage);
        return gardeners;
    }
}
