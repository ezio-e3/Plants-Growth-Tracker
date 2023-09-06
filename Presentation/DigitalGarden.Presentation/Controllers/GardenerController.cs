using DigitalGarden.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Presentation;

[Route("api/[Controller]")]
public class GardenerController : Controller
{
public IMediator Mediator { get; }

    public GardenerController(IMediator mediator)
    {
        Mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GardenerModel model)
        => await Mediator.Send(new CreateGardener {Model = model});
}
