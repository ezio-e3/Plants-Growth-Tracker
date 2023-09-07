using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class UpdateGardener : IRequest<IActionResult>
{
    public required GardenerModel gardenerModel {get; set;}
}
public class UpdateGardenerHandler : IRequestHandler<UpdateGardener, IActionResult>
{ 
    public UpdateGardenerHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get;}
    Task<IActionResult> IRequestHandler<UpdateGardener, IActionResult>.Handle(UpdateGardener request, CancellationToken cancellationToken)
    {
        var gardener = BaseContext.Gardeners.Where(g => g.Id ==request.gardenerModel.Id).FirstOrDefault();
        if(gardener == null)
            return Task.FromResult(new BadRequestObjectResult("Gardener cannot be found") as IActionResult);
        gardener.Name = request.gardenerModel.Name;
        gardener.Email = request.gardenerModel.Email;
        gardener.Gardens = request.gardenerModel.Gardens;
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Gardener updated succesfully") as IActionResult 
            : new BadRequestObjectResult("Unable to update Gardener") as IActionResult);
    }
}
