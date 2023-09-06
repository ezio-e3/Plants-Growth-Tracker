using DigitalGarden.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Presentation;

[Route("api/[Controller]")]
public class PlantController : Controller
{
    public IMediator Mediator { get; }

    public PlantController(IMediator mediator)
    {
        Mediator = mediator;
    }

    // [HttpGet]
    // public async Task<IActionResult> Get([FromQuery] int? id)
    //     => await Mediator.Send(new )

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PlantModel model)
        => await Mediator.Send(new CreatePlant {Model = model});

}
