
namespace DigitalGarden.WebUI;

public interface IGardenerHttpClient
{
    Task<List<GardenerModel>> GetGardeners();
}
