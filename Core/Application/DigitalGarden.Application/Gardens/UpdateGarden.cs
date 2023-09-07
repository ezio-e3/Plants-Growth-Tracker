using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class UpdateGarden : IRequest<IActionResult> 
{
    public required GardenModel gardenModel {get; set;}

}
public class UpdateGardenHandler : IRequestHandler<UpdateGarden, IActionResult>
{
    public UpdateGardenHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get;}
    public Task<IActionResult> Handle(UpdateGarden request, CancellationToken cancellationToken)
    {
        var garden = BaseContext.Gardens.Where(g => g.Id ==request.gardenModel.Id).FirstOrDefault();
        if(garden == null)
            return Task.FromResult(new BadRequestObjectResult("Gardener cannot be found") as IActionResult);
        garden.Name = request.gardenModel.Name;
        garden.Description = request.gardenModel.Description;
        garden.Location = request.gardenModel.Location;
        garden.Maintenances = request.gardenModel.Maintenances;
        garden.Size = request.gardenModel.Size;
        garden.Plants = request.gardenModel.Plants;
        garden.Gardener = request.gardenModel.Gardener;
        garden.GardenerId = request.gardenModel.GardenerId;
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Garden updated succesfully") as IActionResult 
            : new BadRequestObjectResult("Unable to update Garden") as IActionResult);
    }
}
