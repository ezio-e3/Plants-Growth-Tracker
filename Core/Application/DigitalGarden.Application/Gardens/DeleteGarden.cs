using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class DeleteGarden : IRequest<IActionResult>
{   public required int Id { get; set; }
    public required int GardenerId {get; set;}

}
public class DeleteGardenHandler : IRequestHandler<DeleteGarden, IActionResult>
{
    public DeleteGardenHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get;}

    public Task<IActionResult> Handle(DeleteGarden request, CancellationToken cancellationToken)
    {
        //Fix ExecuteDelete() not working
        var garden = BaseContext.Gardens.Where(g => g.Id == request.Id && g.GardenerId == request.GardenerId).FirstOrDefault();
        if (garden == null)
            return Task.FromResult(new BadRequestObjectResult("Garden does not exist") as IActionResult);
        BaseContext.Remove(garden);
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Garden deleted successfully") as IActionResult
            : new BadRequestObjectResult("Unable to delete Garden") as IActionResult);
    }
}
