using DigitalGarden.Domain;

namespace DigitalGarden.Application;

public class PlantRecordModel
{
    public int Id {get; set;}
    public required DateTime DatePlanted {get; set;}
    public int Quantity {get; set;}
    public ICollection<Review>? PlantReviews {get; set;}
    public int PlantId {get; set;}
    public required Plant Plant {get; set;}
}
