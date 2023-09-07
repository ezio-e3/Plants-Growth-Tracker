using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class GetPlantRecords :  IRequest<IActionResult>
{
public int? Id {get; set;}
public required PlantModel PlantModel {get; set;}
}
public class GetPlantRecordsHandler : IRequestHandler<GetPlantRecords, IActionResult>
{
    public GetPlantRecordsHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get; set;}
    public Task<IActionResult> Handle(GetPlantRecords request, CancellationToken cancellationToken)
    {
        if(request.Id == null){
            var plantRecords = BaseContext.PlantRecords.Where(p => p.PlantId == request.PlantModel.Id).ToList();
            return Task.FromResult(new OkObjectResult(plantRecords) as IActionResult);
        }

        var plantRecord = BaseContext.PlantRecords.Where(p => request.Id == p.Id &&
        request.PlantModel.Id == p.PlantId).FirstOrDefault();
        return Task.FromResult(plantRecord == null ? new BadRequestResult() as IActionResult
            : new OkObjectResult(plantRecord) as IActionResult);
    }
}