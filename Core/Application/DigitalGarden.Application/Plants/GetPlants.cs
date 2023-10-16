using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class GetPlants : IRequest<IActionResult>
{
    public int? Id {get; set;}
    public required int GardenId {get; set;}
}
public class GetPlantsHandler : IRequestHandler<GetPlants, IActionResult>{
     public GetPlantsHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get; set;}

    Task<IActionResult> IRequestHandler<GetPlants, IActionResult>.Handle(GetPlants request, CancellationToken cancellationToken)
    {
         if(request.Id == null){
            var plants = BaseContext.Plants.Where(g => g.GardenId == request.GardenId).ToList();
            return Task.FromResult(new OkObjectResult(plants) as IActionResult);
        }

        var plant = BaseContext.Plants.Where(g => request.Id == g.Id &&
        request.Id == g.GardenId).FirstOrDefault();
        return Task.FromResult(plant == null ? new BadRequestResult() as IActionResult
            : new OkObjectResult(plant) as IActionResult);
    }
}
