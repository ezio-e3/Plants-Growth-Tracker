using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class CreatePlantRecord : IRequest<IActionResult>
{
    public required PlantRecordModel Model {get; set;}
}
public class CreatePlantRecordHandler : IRequestHandler<CreatePlantRecord, IActionResult>
{
    public CreatePlantRecordHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get;}
    Task<IActionResult> IRequestHandler<CreatePlantRecord, IActionResult>.Handle(CreatePlantRecord request, CancellationToken cancellationToken)
    {
        var plantRecord = new PlantRecord {
            DatePlanted = request.Model.DatePlanted, 
            Quantity = request.Model.Quantity, 
            PlantReviews = request.Model.PlantReviews, 
            Plant = request.Model.Plant, 
            PlantId = request.Model.PlantId};
        
        BaseContext.Add(plantRecord);
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("New plant record added") as IActionResult
            : new BadRequestObjectResult("Could not add new plant record"));
    }
}
