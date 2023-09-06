namespace DigitalGarden.Domain;

public class Gardener
{
    public int Id {get; set;}
    public required string Name {get; set;}
    public string? Email {get; set;}
    
    public ICollection<Garden>? Gardens {get; set;}
}
