using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class DeletePlant : IRequest<IActionResult>
{
    public int Id {get; set;}
    public int GardenId {get; set;}

}
public class DeletePlantHandler : IRequestHandler<DeletePlant, IActionResult>
{
    public DeletePlantHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get;}

    public Task<IActionResult> Handle(DeletePlant request, CancellationToken cancellationToken)
    {
        //Fix ExecuteDelete() not working
        var plant = BaseContext.Plants.Where(p => p.Id == request.Id && p.GardenId == request.GardenId).FirstOrDefault();
        if (plant == null)
            return Task.FromResult(new BadRequestObjectResult("Plant does not exist") as IActionResult);
        BaseContext.Remove(plant);
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Plant deleted successfully") as IActionResult
            : new BadRequestObjectResult("Unable to delete plant") as IActionResult);
    }
}
