using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class DeleteMaintenance : IRequest<IActionResult>
{
    public required int Id {get; set;}
    public int? PlantId {get; set;}
    public int? GardenId {get; set;}
}
public class DeleteMaintenanceHandler : IRequestHandler<DeleteMaintenance, IActionResult>
{
    public DeleteMaintenanceHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get;}
    public Task<IActionResult> Handle(DeleteMaintenance request, CancellationToken cancellationToken)
    {
         //Fix ExecuteDelete() not working
        var maintenanceTask = BaseContext.MaintenanceTasks.Where(m => m.Id == request.Id && 
        (m.GardenId == request.GardenId || m.PlantId == request.PlantId)).FirstOrDefault();
        if (maintenanceTask == null)
            return Task.FromResult(new BadRequestObjectResult("Maintenance task does not exist") as IActionResult);
        BaseContext.Remove(maintenanceTask);
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Maintenance task deleted successfully") as IActionResult
            : new BadRequestObjectResult("Unable to delete maintenance task") as IActionResult);
    }
}
