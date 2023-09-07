using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class DeletePlantRecords : IRequest<IActionResult>
{
    public int Id {get; set;}
}
public class DeletePlantRecordsHandler : IRequestHandler<DeletePlantRecords, IActionResult>{
    public DeletePlantRecordsHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get;}

    public Task<IActionResult> Handle(DeletePlantRecords request, CancellationToken cancellationToken)
    {
        //Fix ExecuteDelete() not working
        var plantRecord = BaseContext.PlantRecords.Find(request.Id);
        if (plantRecord == null)
            return Task.FromResult(new BadRequestObjectResult("Plant record does not exist") as IActionResult);
        BaseContext.Remove(plantRecord);
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Plant record deleted successfully") as IActionResult
            : new BadRequestObjectResult("Unable to delete plant record") as IActionResult);
    }
}
