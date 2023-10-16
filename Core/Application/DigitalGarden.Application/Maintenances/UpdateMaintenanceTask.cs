using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class UpdateMaintenanceTask : IRequest<IActionResult>
{
    public required int Id {get; set;}
    public int? GardenId {get; set;}
    public int? PlantId {get; set;}
    public required MaintenanceTaskModel MaintenanceTaskModel {get; set;}
}
public class UpdateMaintenanceTaskHandler : IRequestHandler<UpdateMaintenanceTask, IActionResult>{
    public UpdateMaintenanceTaskHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get; set;}

    public Task<IActionResult> Handle(UpdateMaintenanceTask request, CancellationToken cancellationToken)
    {        
        var maintenanceTask = BaseContext.MaintenanceTasks.Where(m => m.Id == request.Id && 
        (m.GardenId == request.GardenId || m.PlantId == request.PlantId)).FirstOrDefault();
        if(maintenanceTask == null)
            return Task.FromResult(new BadRequestObjectResult("Maintenance task does not exist") as IActionResult);
        maintenanceTask.DueDate = request.MaintenanceTaskModel.DueDate;
        maintenanceTask.Description = request.MaintenanceTaskModel.Description;
        maintenanceTask.TaskName = request.MaintenanceTaskModel.TaskName;
        maintenanceTask.Completed = request.MaintenanceTaskModel.Completed;
        if(maintenanceTask.PlantId.HasValue){
            maintenanceTask.Plant = request.MaintenanceTaskModel.Plant;
            maintenanceTask.PlantId = request.MaintenanceTaskModel.PlantId;
        }
        if(maintenanceTask.GardenId.HasValue){
            maintenanceTask.Garden = request.MaintenanceTaskModel.Garden;
            maintenanceTask.GardenId = request.MaintenanceTaskModel.GardenId;
        }
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Maintenance task updated succesfully") as IActionResult 
            : new BadRequestObjectResult("Unable to update maintenance task") as IActionResult);
    }
}
