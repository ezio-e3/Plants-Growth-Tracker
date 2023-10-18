
namespace DigitalGarden.WebUI;

public interface IGardenerHttpClient
{
    Task<List<GardenerModel>> GetGardeners();
    Task<GardenerModel> GetGardener(int id);
    Task<string> CreateGardener(GardenerModel model);
    Task<GardenerModel> UpdateGardener(int id, GardenerModel model);
    Task<GardenerModel> DeleteGardener(int id);
}
