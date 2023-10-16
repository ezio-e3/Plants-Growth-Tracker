using DigitalGarden.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Presentation;

[Route("api/[Controller]/[action]")]
public class MaintenanceController : Controller
{
public IMediator Mediator { get; }

    public MaintenanceController(IMediator mediator)
    {
        Mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllMaintenanceTasks([FromQuery] int id) 
        => await Mediator.Send(new GetMaintenanceTask{Id = id});

    [HttpGet("{id}/{plantId}")]
    public async Task<IActionResult> GetPlantMaintenanceTask([FromQuery] int id ,[FromQuery] int plantId) 
        => await Mediator.Send(new GetMaintenanceTask{Id = id ,PlantId = plantId});

    [HttpGet("{id}/{gardenId}")]
    public async Task<IActionResult> GetGardenMaintenanceTask([FromQuery] int id ,[FromQuery] int gardenId) 
        => await Mediator.Send(new GetMaintenanceTask{Id = id ,GardenId = gardenId});

    [HttpPost]
    public async Task<IActionResult> CreateMaintenanceTask([FromBody] MaintenanceTaskModel model)
        => await Mediator.Send(new CreateMaintenanceTask {Model = model});

    [HttpPut("{id}/{plantId}")]
    public async Task<IActionResult> UpdatePlantMaintenenaceTask([FromQuery] int id, [FromQuery] int plantId, [FromBody] MaintenanceTaskModel model)
        => await Mediator.Send(new UpdateMaintenanceTask {Id = id ,PlantId = plantId ,MaintenanceTaskModel = model});


     [HttpPut("{id}/{gardenId}")]
    public async Task<IActionResult> UpdateGardenMaintenenaceTask([FromQuery] int id, [FromQuery] int gardenId, [FromBody] MaintenanceTaskModel model)
        => await Mediator.Send(new UpdateMaintenanceTask {Id = id ,GardenId = gardenId ,MaintenanceTaskModel = model});

    [HttpDelete("{id}/{gardenId}")]
    public async Task<IActionResult> DeleteGardenMaintenenaceTask([FromQuery] int id, [FromQuery] int gardenId)
        => await Mediator.Send(new DeleteMaintenance {Id = id ,GardenId = gardenId});

    [HttpDelete("{id}/{plantId}")]
    public async Task<IActionResult> DeletePlantMaintenenaceTask([FromQuery] int id, [FromQuery] int plantId)
        => await Mediator.Send(new DeleteMaintenance {Id = id ,PlantId = plantId});
}
