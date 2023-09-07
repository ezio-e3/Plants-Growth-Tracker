using DigitalGarden.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Presentation;

[Route("api/[Controller]")]
public class MaintenanceController : Controller
{
public IMediator Mediator { get; }

    public MaintenanceController(IMediator mediator)
    {
        Mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPlantMaintenanceTasks([FromQuery] PlantModel plantModel) 
        => await Mediator.Send(new GetMaintenanceTask{PlantModel = plantModel});

    [HttpGet]
    public async Task<IActionResult> GetPlantMaintenanceTask([FromQuery] int id ,[FromQuery] PlantModel plantModel) 
        => await Mediator.Send(new GetMaintenanceTask{Id = id ,PlantModel = plantModel});

    [HttpGet]
    public async Task<IActionResult> GetAllGardenMaintenanceTasks([FromQuery] GardenModel gardenModel) 
        => await Mediator.Send(new GetMaintenanceTask{GardenModel = gardenModel});

    [HttpGet]
    public async Task<IActionResult> GetGardenMaintenanceTask([FromQuery] int id ,[FromQuery] GardenModel gardenModel) 
        => await Mediator.Send(new GetMaintenanceTask{Id = id ,GardenModel = gardenModel});

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MaintenanceTaskModel model)
        => await Mediator.Send(new CreateMaintenanceTask {Model = model});
}
