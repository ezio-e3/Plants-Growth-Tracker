
namespace DigitalGarden.WebUI;

public interface IGardenerHttpClient
{
    Task<List<GardenerModel>> GetGardeners();
    Task<GardenerModel>GetGardener(int gardenerId);
}
