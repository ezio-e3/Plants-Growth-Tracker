using DigitalGarden.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Presentation;

[Route("api/[Controller]/[action]")]
public class GardenerController : Controller
{
public IMediator Mediator { get; }

    public GardenerController(IMediator mediator)
    {
        Mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGardeners() 
        => await Mediator.Send(new GetGardener{});

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGardener([FromQuery] int? id)
        => await Mediator.Send(new GetGardener {Id = id});

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GardenerModel model)
        => await Mediator.Send(new CreateGardener {Model = model});
}
