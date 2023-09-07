using DigitalGarden.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Presentation;

[Route("api/[Controller]")]
public class PlantRecordController : Controller
{
public IMediator Mediator { get; }

    public PlantRecordController(IMediator mediator)
    {
        Mediator = mediator;
    }

     [HttpGet]
    public async Task<IActionResult> GetAllPlantRecords([FromQuery] PlantModel plantModel) 
        => await Mediator.Send(new GetPlantRecords{ PlantModel = plantModel});

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGardener([FromQuery] int id, [FromQuery] PlantModel plantModel)
        => await Mediator.Send(new GetPlantRecords {Id = id,  PlantModel= plantModel});

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PlantRecordModel model)
        => await Mediator.Send(new CreatePlantRecord {Model = model});
}
