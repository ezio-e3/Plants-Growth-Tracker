using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class UpdateGarden : IRequest<IActionResult> 
{
    public required GardenerModel GardenerModel {get; set;}
    public required GardenModel Model {get; set;}

}
public class UpdateGardenHandler : IRequestHandler<UpdateGarden, IActionResult>
{
    public UpdateGardenHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get;}
    public Task<IActionResult> Handle(UpdateGarden request, CancellationToken cancellationToken)
    {
        var garden = BaseContext.Gardens.Where(g => g.Id ==request.Model.Id &&
        request.GardenerModel.Id == g.Id).FirstOrDefault();
        if(garden == null)
            return Task.FromResult(new BadRequestObjectResult("Gardener cannot be found") as IActionResult);
        garden.Name = request.Model.Name;
        garden.Description = request.Model.Description;
        garden.Location = request.Model.Location;
        garden.Maintenances = request.Model.Maintenances;
        garden.Size = request.Model.Size;
        garden.Plants = request.Model.Plants;
        garden.Gardener = request.Model.Gardener;
        garden.GardenerId = request.Model.GardenerId;
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Garden updated succesfully") as IActionResult 
            : new BadRequestObjectResult("Unable to update Garden") as IActionResult);
    }
}
