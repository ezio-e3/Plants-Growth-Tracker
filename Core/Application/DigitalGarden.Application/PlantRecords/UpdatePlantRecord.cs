using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class UpdatePlantRecord : IRequest<IActionResult>
{
    public required int Id {get; set;}
    public required int PlantId {get; set;}
    public required PlantRecordModel PlantRecordModel {get; set;}
}
public class UpdatePlantRecordHandler : IRequestHandler<UpdatePlantRecord, IActionResult>
{
    public UpdatePlantRecordHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get; set;}
    Task<IActionResult> IRequestHandler<UpdatePlantRecord, IActionResult>.Handle(UpdatePlantRecord request, CancellationToken cancellationToken)
    {
        var plantRecord = BaseContext.PlantRecords.Where(p => p.Id == request.Id && p.PlantId == request.PlantId).FirstOrDefault();
        if(plantRecord == null)
            return Task.FromResult(new BadRequestObjectResult("Plant record does not exist") as IActionResult);
        plantRecord.DatePlanted = request.PlantRecordModel.DatePlanted;
        plantRecord.PlantReviews = request.PlantRecordModel.PlantReviews;
        plantRecord.Plant = request.PlantRecordModel.Plant;
        plantRecord.PlantId = request.PlantRecordModel.PlantId;
        plantRecord.Quantity = request.PlantRecordModel.Quantity;
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Record updated succesfully") as IActionResult 
            : new BadRequestObjectResult("Unable to update record") as IActionResult);
    }
}