using DigitalGarden.Domain;

namespace DigitalGarden.Application;

public class GardenerModel
{
    public int Id {get; set;}
    public required string Name {get; set;}
    public string? Email {get; set;}
    
    public ICollection<Garden>? Gardens {get; set;}
}
