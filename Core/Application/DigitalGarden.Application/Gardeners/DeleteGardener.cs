using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DigitalGarden.Application;

public class DeleteGardener : IRequest<IActionResult>
{
    public int Id { get; set; }
}
public class DeleteGardenerHandler : IRequestHandler<DeleteGardener, IActionResult>
{
    public DeleteGardenerHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get;}
    Task<IActionResult> IRequestHandler<DeleteGardener, IActionResult>.Handle(DeleteGardener request, CancellationToken cancellationToken)
    {
        //Fix ExecuteDelete() not working
        var gardener = BaseContext.Gardeners.Find(request.Id);
        if (gardener == null)
            return Task.FromResult(new BadRequestObjectResult("Gardener does not exist") as IActionResult);
        BaseContext.Remove(gardener);
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Gardener deleted successfully") as IActionResult
            : new BadRequestObjectResult("Unable to delete Gardener") as IActionResult);
    }
}