namespace DigitalGarden.Domain;

public class MaintenanceTask
{
    public int Id {get; set;}
    public required string TaskName {get; set;}
    public required DateTime DueDate {get; set;}
    public string? Description {get; set;}
    public bool Completed {get; set;}

      //FK
    public int? GardenId {get; set;}
    public Garden? Garden {get; set;}
    public int? PlantId {get; set;}
    public Plant? Plant {get; set;}
}
