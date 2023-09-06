namespace DigitalGarden.Domain;

public class PlantRecord
{
    public int Id {get; set;}
    public required DateTime DatePlanted {get; set;}
    public int Quantity {get; set;}
    public ICollection<Review>? PlantReviews {get; set;}

    //FK
    public int PlantId {get; set;}
    public required Plant Plant {get; set;}
}
