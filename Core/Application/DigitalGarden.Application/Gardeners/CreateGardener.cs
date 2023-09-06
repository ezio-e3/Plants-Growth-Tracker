using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class CreateGardener : IRequest<IActionResult>
{
    public required GardenerModel Model {get; set;}
}
public class CreateGardenerHandler : IRequestHandler<CreateGardener, IActionResult>
{
    public CreateGardenerHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get;}
    Task<IActionResult> IRequestHandler<CreateGardener, IActionResult>.Handle(CreateGardener request, CancellationToken cancellationToken)
    {
        var gardener = new Gardener {
            Name = request.Model.Name, 
            Email = request.Model.Email, 
            Gardens = request.Model.Gardens
            };
        
        BaseContext.Add(gardener);
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Gardener Created Succesfully") as IActionResult
            : new BadRequestObjectResult("Gardener cannot be Created") as IActionResult);
    }
}
