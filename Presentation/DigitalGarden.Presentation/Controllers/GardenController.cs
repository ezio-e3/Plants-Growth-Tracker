using DigitalGarden.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Presentation;
[Route("api/[Controller]/[action]")]
public class GardenController : Controller
{
public IMediator Mediator { get; }

    public GardenController(IMediator mediator)
    {
        Mediator = mediator;
    }
     [HttpGet("{gardenerId}")]
    public async Task<IActionResult> GetGardens([FromQuery] int gardenerId) 
        => await Mediator.Send(new GetGarden{GardenerId = gardenerId});

    [HttpGet("{id}/{gardenerId}")]
    public async Task<IActionResult> GetGarden([FromQuery] int id, [FromQuery] int gardenerId)
        => await Mediator.Send(new GetGarden {Id = id, GardenerId = gardenerId});

    [HttpPost]
    public async Task<IActionResult> CreateGarden([FromBody] GardenModel model)
        => await Mediator.Send(new CreateGarden {Model = model});

    [HttpPut]
    public async Task<IActionResult> UpdateGarden([FromBody] GardenerModel gardenerModel, [FromBody] GardenModel model)
        => await Mediator.Send(new UpdateGarden {GardenerModel = gardenerModel ,Model = model});

    [HttpDelete("{id}/{gardenerId}")]
    public async Task<IActionResult> DeleteGarden([FromQuery] int id, [FromQuery] int gardenerId)
        => await Mediator.Send(new DeleteGarden {Id = id, GardenerId = gardenerId});
}
