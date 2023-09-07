using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class UpdateMaintenanceTask : IRequest<IActionResult>
{
    public required MaintenanceTaskModel maintenanceTaskModel {get; set;}
}
public class UpdateMaintenanceTaskHandler : IRequestHandler<UpdateMaintenanceTask, IActionResult>{
    public UpdateMaintenanceTaskHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get; set;}

    public Task<IActionResult> Handle(UpdateMaintenanceTask request, CancellationToken cancellationToken)
    {
        var maintenanceTask = BaseContext.MaintenanceTasks.Where(m => m.Id == request.maintenanceTaskModel.Id).FirstOrDefault();
        if(maintenanceTask == null)
            return Task.FromResult(new BadRequestObjectResult("Maintenance task does not exist") as IActionResult);
        maintenanceTask.DueDate = request.maintenanceTaskModel.DueDate;
        maintenanceTask.Description = request.maintenanceTaskModel.Description;
        maintenanceTask.TaskName = request.maintenanceTaskModel.TaskName;
        maintenanceTask.Completed = request.maintenanceTaskModel.Completed;
        if(maintenanceTask.PlantId.HasValue){
            maintenanceTask.Plant = request.maintenanceTaskModel.Plant;
            maintenanceTask.PlantId = request.maintenanceTaskModel.PlantId;
        }
        if(maintenanceTask.GardenId.HasValue){
            maintenanceTask.Garden = request.maintenanceTaskModel.Garden;
            maintenanceTask.GardenId = request.maintenanceTaskModel.GardenId;
        }
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Maintenance task updated succesfully") as IActionResult 
            : new BadRequestObjectResult("Unable to update maintenance task") as IActionResult);
    }
}
