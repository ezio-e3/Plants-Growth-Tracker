using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class GetGarden : IRequest<IActionResult>
{
    public required int GardenerId { get; set; }
    public int? Id { get; set; }
}
public class GetGardenHandler : IRequestHandler<GetGarden, IActionResult>
{
    public GetGardenHandler(BaseDigitalGardenContext baseDigitalGardenContext)
    {
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext { get; set; }

    Task<IActionResult> IRequestHandler<GetGarden, IActionResult>.Handle(GetGarden request, CancellationToken cancellationToken)
    {
        if(request.Id == null){
            var gardens = BaseContext.Gardens.Where(g => g.GardenerId == request.Id).ToList();
            return Task.FromResult(new OkObjectResult(gardens) as IActionResult);
        }

        var garden = BaseContext.Gardens.Where(g => request.Id == g.Id &&
        request.GardenerId == g.GardenerId).FirstOrDefault();
        return Task.FromResult(garden == null ? new BadRequestResult() as IActionResult
            : new OkObjectResult(garden) as IActionResult);
    }
}
