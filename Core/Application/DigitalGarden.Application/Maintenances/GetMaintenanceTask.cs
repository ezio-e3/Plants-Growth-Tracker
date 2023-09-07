using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class GetMaintenanceTask : IRequest<IActionResult>
{
    public int? Id {get; set;}
    public PlantModel? PlantModel {get; set;}
    public GardenModel? GardenModel {get; set;}
}
public class GetMaintenanceTaskHandler : IRequestHandler<GetMaintenanceTask, IActionResult>
{
    public GetMaintenanceTaskHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get; set;}
    Task<IActionResult> IRequestHandler<GetMaintenanceTask, IActionResult>.Handle(GetMaintenanceTask request, CancellationToken cancellationToken)
    {
        if (request.PlantModel != null){
            if (request.Id == null){
                var plantMaintenanceTasks = BaseContext.MaintenanceTasks.Where(m => m.PlantId == request.PlantModel.Id).ToList();
                return Task.FromResult(new OkObjectResult(plantMaintenanceTasks) as IActionResult);
            }
            var plantMaintenanceTask = BaseContext.MaintenanceTasks.Where(m => m.PlantId == request.PlantModel.Id &&
            m.Id == request.Id).FirstOrDefault();
            return Task.FromResult(plantMaintenanceTask == null ? new BadRequestResult() as IActionResult
                : new OkObjectResult(plantMaintenanceTask) as IActionResult);
        }
        else if (request.GardenModel != null){
            if (request.Id == null){
                var gardenMaintenanceTasks = BaseContext.MaintenanceTasks.Where(m => m.GardenId == request.GardenModel.Id).ToList();
                return Task.FromResult(new OkObjectResult(gardenMaintenanceTasks) as IActionResult);
            }
            var gardenMaintenanceTask = BaseContext.MaintenanceTasks.Where(m => m.GardenId == request.GardenModel.Id &&
            m.Id == request.Id).FirstOrDefault();
            return Task.FromResult(gardenMaintenanceTask == null ? new BadRequestResult() as IActionResult
                : new OkObjectResult(gardenMaintenanceTask) as IActionResult);
        }
        return Task.FromResult(new BadRequestObjectResult("Maintenance must be associated with either a Plant or Garden") as IActionResult);
    }
}
