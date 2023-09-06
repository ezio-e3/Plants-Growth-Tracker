namespace DigitalGarden.Domain;

public class Garden
{
    public int Id {get; set;}
    public required string Name {get; set;}
    public required string Location {get; set;}
    public int Size {get; set;}
    public string? Description {get; set;}

    public ICollection<Plant>? Plants {get; set;}
    public ICollection<MaintenanceTask>? Maintenances {get; set;}
    //FK
    public int GardenerId {get; set;}
    public required Gardener Gardener {get; set;}
}
