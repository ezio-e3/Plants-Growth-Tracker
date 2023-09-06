using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class CreateMaintenanceTask : IRequest<IActionResult>
{
    public required MaintenanceTaskModel Model {get; set;}
}
public class CreateMaintenanceTaskHandler : IRequestHandler<CreateMaintenanceTask, IActionResult>
{
    public CreateMaintenanceTaskHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get;}
    Task<IActionResult> IRequestHandler<CreateMaintenanceTask, IActionResult>.Handle(CreateMaintenanceTask request, CancellationToken cancellationToken)
    {
        var maintenenance = new MaintenanceTask {
            TaskName = request.Model.TaskName, 
            Description = request.Model.Description, 
            DueDate = request.Model.DueDate, 
            Completed = request.Model.Completed, 
            Garden = request.Model.Garden, 
            GardenId = request.Model.GardenId, 
            Plant = request.Model.Plant, 
            PlantId = request.Model.PlantId
            };
       
        BaseContext.Add(maintenenance);
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Maintenance Task Created Succesfully") as IActionResult
                : new BadRequestObjectResult("Maintenance Task cannot be Created") as IActionResult);
    }
}
