using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class CreateGarden : IRequest<IActionResult>
{
    public required GardenModel Model {get; set;}
}
public class CreateGardenHandler : IRequestHandler<CreateGarden, IActionResult>
{
    public CreateGardenHandler(BaseDigitalGardenContext baseDigitalGardenContext)
    {
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get;}
    Task<IActionResult> IRequestHandler<CreateGarden, IActionResult>.Handle(CreateGarden request, CancellationToken cancellationToken)
    {
        var garden = new Garden {
            Name = request.Model.Name, 
            Location = request.Model.Location, 
            Description = request.Model.Description, 
            Size = request.Model.Size, 
            GardenerId = request.Model.GardenerId, 
            Gardener = request.Model.Gardener, 
            Plants = request.Model.Plants, 
            Maintenances = request.Model.Maintenances
            };
            
            BaseContext.Add(garden);
            return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Garden Created Succesfully") as IActionResult
                : new BadRequestObjectResult("Garden cannot be Created") as IActionResult);
    }
}