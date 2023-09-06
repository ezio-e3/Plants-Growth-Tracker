namespace DigitalGarden.Domain;

public class Plant
{
    public int Id {get; set;}
    public PlantType PlantType {get; set;}
    public required string CommonName {get; set;}
    public string? ScientificName {get; set;}
    public string? Description {get; set;}
    public string? PlantingSeason {get; set;}
    public string? GrowthCycle {get; set;}
    public string? SunlightRequirement {get; set;}
    public string? WateringFrequency {get; set;}
    public string? SoilTypePreference {get; set;}

    public ICollection<PlantRecord>? PlantRecords {get; set;}
    public ICollection<MaintenanceTask>? Maintenances {get; set;}
    public int GardenId {get; set;}
    public required Garden Garden {get; set;}
}
