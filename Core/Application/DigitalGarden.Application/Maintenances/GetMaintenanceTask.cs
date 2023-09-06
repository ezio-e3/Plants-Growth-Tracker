﻿using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class GetMaintenanceTask : IRequest<IActionResult>
{
    public int? Id {get; set;}
    public Plant? Plant {get; set;}
    public Garden? Garden {get; set;}
}
public class GetMaintenanceTaskHandler : IRequestHandler<GetMaintenanceTask, IActionResult>
{
    public GetMaintenanceTaskHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get; set;}
    Task<IActionResult> IRequestHandler<GetMaintenanceTask, IActionResult>.Handle(GetMaintenanceTask request, CancellationToken cancellationToken)
    {
        if (request.Plant != null){
            if (request.Id == null){
                var plantMaintenanceTasks = BaseContext.MaintenanceTasks.Where(m => m.PlantId == request.Plant.Id).ToList();
                return Task.FromResult(new OkObjectResult(plantMaintenanceTasks) as IActionResult);
            }
            var plantMaintenanceTask = BaseContext.MaintenanceTasks.Where(m => m.PlantId == request.Plant.Id &&
            m.Id == request.Id).FirstOrDefault();
            return Task.FromResult(plantMaintenanceTask == null ? new BadRequestResult() as IActionResult
                : new OkObjectResult(plantMaintenanceTask) as IActionResult);
        }
        else if (request.Garden != null){
            if (request.Id == null){
                var gardenMaintenanceTasks = BaseContext.MaintenanceTasks.Where(m => m.GardenId == request.Garden.Id).ToList();
                return Task.FromResult(new OkObjectResult(gardenMaintenanceTasks) as IActionResult);
            }
            var gardenMaintenanceTask = BaseContext.MaintenanceTasks.Where(m => m.GardenId == request.Garden.Id &&
            m.Id == request.Id).FirstOrDefault();
            return Task.FromResult(gardenMaintenanceTask == null ? new BadRequestResult() as IActionResult
                : new OkObjectResult(gardenMaintenanceTask) as IActionResult);
        }
        return Task.FromResult(new BadRequestObjectResult("Maintenance must be associated with either a Plant or Garden") as IActionResult);
    }
}
