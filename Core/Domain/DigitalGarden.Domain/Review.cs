namespace DigitalGarden.Domain;

public class Review
{
    public int Id {get; set;}
    public GrowthStage GrowthStage {get; set;}
    public DateTime ReviewTime {get; set;}
    public required string Note {get; set;}

    //FK
    public int PlantRecordId {get; set;}
    public required PlantRecord PlantRecord {get; set;}

}
