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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GardenModel model)
        => await Mediator.Send(new CreateGarden {Model = model});
}
