using DigitalGarden.Domain;

namespace DigitalGarden.Application;

public class ReviewModel
{
    public int Id {get; set;}
    public GrowthStage GrowthStage {get; set;}
    public DateTime ReviewTime {get; set;}
    public required string Note {get; set;}
    public int PlantRecordId {get; set;}
    public required PlantRecord PlantRecord {get; set;}
}
