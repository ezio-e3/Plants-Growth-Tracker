using DigitalGarden.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Presentation;
[Route("api/[Controller]")]
public class GardenController : Controller
{
public IMediator Mediator { get; }

    public GardenController(IMediator mediator)
    {
        Mediator = mediator;
    }
     [HttpGet]
    public async Task<IActionResult> GetAllGardens([FromQuery] GardenerModel gardenerModel) 
        => await Mediator.Send(new GetGarden{Gardener = gardenerModel});

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGarden([FromQuery] int id, [FromQuery] GardenerModel gardenerModel)
        => await Mediator.Send(new GetGarden {Id = id, Gardener = gardenerModel});

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GardenModel model)
        => await Mediator.Send(new CreateGarden {Model = model});
}
