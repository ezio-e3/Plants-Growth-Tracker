using DigitalGarden.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Presentation;

[Route("api/[Controller]/[action]")]
public class PlantController : Controller
{
    public IMediator Mediator { get; }

    public PlantController(IMediator mediator)
    {
        Mediator = mediator;
    }

     [HttpGet("{gardenId}")]
    public async Task<IActionResult> GetPlants([FromQuery] int gardenId) 
        => await Mediator.Send(new GetPlants{GardenId = gardenId});

    [HttpGet("{id}/{gardenId}")]
    public async Task<IActionResult> GetPlant([FromQuery] int id, [FromQuery] int gardenId)
        => await Mediator.Send(new GetPlants {Id = id, GardenId = gardenId});

    [HttpPost]
    public async Task<IActionResult> CreatePlant([FromBody] PlantModel model)
        => await Mediator.Send(new CreatePlant {Model = model});

    [HttpPut("{id}/{gardenId}")]
    public async Task<IActionResult> UpdatePlant([FromQuery] int id ,[FromQuery] int gardenId, [FromBody] PlantModel model)
        => await Mediator.Send(new UpdatePlant {Id = id, GardenId = gardenId, PlantModel = model});

    [HttpDelete("{id/{gardenId}}")]
    public async Task<IActionResult> DeletePlant([FromQuery] int id, [FromQuery] int gardenId)
        => await Mediator.Send(new DeletePlant {Id = id, GardenId = gardenId});

}
