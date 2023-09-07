using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class DeleteGarden : IRequest<IActionResult>
{
    public int Id { get; set; }
}
public class DeleteGardenHandler : IRequestHandler<DeleteGardener, IActionResult>
{
    public DeleteGardenHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get;}

    public Task<IActionResult> Handle(DeleteGardener request, CancellationToken cancellationToken)
    {
        //Fix ExecuteDelete() not working
        var garden = BaseContext.Gardens.Find(request.Id);
        if (garden == null)
            return Task.FromResult(new BadRequestObjectResult("Garden does not exist") as IActionResult);
        BaseContext.Remove(garden);
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Garden deleted successfully") as IActionResult
            : new BadRequestObjectResult("Unable to delete Garden") as IActionResult);
    }
}
