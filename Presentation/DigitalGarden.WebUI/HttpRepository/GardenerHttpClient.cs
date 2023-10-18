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
        var response = await HttpClient.GetAsync("Gardener/GetGardeners");
        var content = await response.Content.ReadAsStringAsync();
        // if(!response.IsSuccessStatusCode){
        //     throw new ApplicationException();
        // }
        var gardeners = JsonSerializer.Deserialize<List<GardenerModel>>(content, Options);
        return gardeners;
    }

    public async Task<GardenerModel> GetGardener(int id)
    {
        var response = await HttpClient.GetAsync("Gardener/GetGardener/{id}");
        var content = await response.Content.ReadAsStringAsync();
        var gardener = JsonSerializer.Deserialize<GardenerModel>(content, Options);
        return gardener;
    }

    Task<GardenerModel> IGardenerHttpClient.CreateGardener(GardenerModel model)
    {
        throw new NotImplementedException();
    }

    Task<GardenerModel> IGardenerHttpClient.DeleteGardener(int id)
    {
        throw new NotImplementedException();
    }

    Task<GardenerModel> IGardenerHttpClient.UpdateGardener(int id, GardenerModel model)
    {
        throw new NotImplementedException();
    }
}
