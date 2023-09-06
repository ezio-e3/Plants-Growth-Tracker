using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class GetGardener : IRequest<IActionResult>
{
    public int? Id {get; set;}
}
public class GetGardenerHandler : IRequestHandler<GetGardener, IActionResult>
{
    public GetGardenerHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }

    public BaseDigitalGardenContext BaseContext {get; set;}
    Task<IActionResult> IRequestHandler<GetGardener, IActionResult>.Handle(GetGardener request, CancellationToken cancellationToken)
    {
        if (request.Id == null){
            var gardeners = BaseContext.Gardeners.ToList();
            return Task.FromResult(new OkObjectResult(gardeners) as IActionResult);
        }
        var gardener = BaseContext.Gardeners.Where(g => g.Id == request.Id).FirstOrDefault();
        return Task.FromResult(gardener == null ? new BadRequestResult() as IActionResult
            : new OkObjectResult(gardener) as IActionResult);

    }
}
