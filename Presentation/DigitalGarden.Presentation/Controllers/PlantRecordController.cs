using DigitalGarden.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Presentation;

[Route("api/[Controller]/[action]")]
public class PlantRecordController : Controller
{
public IMediator Mediator { get; }

    public PlantRecordController(IMediator mediator)
    {
        Mediator = mediator;
    }

     [HttpGet("{plantId}")]
    public async Task<IActionResult> GetPlantRecords([FromQuery] int plantId) 
        => await Mediator.Send(new GetPlantRecords{ PlantId = plantId});

    [HttpGet("{id}/{plantId}")]
    public async Task<IActionResult> GetPlantRecord([FromQuery] int id, [FromQuery] int plantId)
        => await Mediator.Send(new GetPlantRecords {Id = id,  PlantId = plantId});

    [HttpPost]
    public async Task<IActionResult> CreatePlantRecord([FromBody] PlantRecordModel model)
        => await Mediator.Send(new CreatePlantRecord {Model = model});

    [HttpPut("{id}/{plantId}")]
    public async Task<IActionResult> UpdatePlantRecord([FromQuery] int id, [FromQuery] int plantId, [FromBody] PlantRecordModel model)
        => await Mediator.Send(new UpdatePlantRecord {Id = id,  PlantId = plantId, PlantRecordModel = model});

    
    [HttpDelete("{id}/{plantId}")]
    public async Task<IActionResult> DeletePlantRecord([FromQuery] int id, [FromQuery] int plantId)
        => await Mediator.Send(new DeletePlantRecords {Id = id,  PlantId = plantId});
}
