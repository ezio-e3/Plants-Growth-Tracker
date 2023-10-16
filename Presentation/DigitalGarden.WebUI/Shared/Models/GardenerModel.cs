using System.ComponentModel.DataAnnotations;
using DigitalGarden.Domain;

namespace DigitalGarden.WebUI;

public class GardenerModel
{
    public int Id {get; set;}
    [Required]
    public string? Name {get; set;}
    public string? Email {get; set;}
    
    public ICollection<Garden>? Gardens {get; set;}
}
