using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class UpdatePlantRecord : IRequest<IActionResult>
{
    public required PlantRecordModel plantRecordModel {get; set;}
}
public class UpdatePlantRecordHandler : IRequestHandler<UpdatePlantRecord, IActionResult>
{
    public UpdatePlantRecordHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get; set;}
    Task<IActionResult> IRequestHandler<UpdatePlantRecord, IActionResult>.Handle(UpdatePlantRecord request, CancellationToken cancellationToken)
    {
        var plantRecord = BaseContext.PlantRecords.Where(p => p.Id == request.plantRecordModel.Id).FirstOrDefault();
        if(plantRecord == null)
            return Task.FromResult(new BadRequestObjectResult("Plant record does not exist") as IActionResult);
        plantRecord.DatePlanted = request.plantRecordModel.DatePlanted;
        plantRecord.PlantReviews = request.plantRecordModel.PlantReviews;
        plantRecord.Plant = request.plantRecordModel.Plant;
        plantRecord.PlantId = request.plantRecordModel.PlantId;
        plantRecord.Quantity = request.plantRecordModel.Quantity;
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Record updated succesfully") as IActionResult 
            : new BadRequestObjectResult("Unable to update record") as IActionResult);
    }
}