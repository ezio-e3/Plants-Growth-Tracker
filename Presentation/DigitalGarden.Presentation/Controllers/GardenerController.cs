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
    public async Task<IActionResult> GetGardeners() 
        => await Mediator.Send(new GetGardener{});

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGardener([FromQuery] int? id)
        => await Mediator.Send(new GetGardener {Id = id});

    [HttpPost]
    public async Task<IActionResult> CreateGardener([FromBody] GardenerModel model)
        => await Mediator.Send(new CreateGardener {Model = model});

    [HttpPut]
    public async Task<IActionResult> UpdateGardener([FromBody] GardenerModel model)
        => await Mediator.Send(new UpdateGardener {Model = model});

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGardener([FromQuery] int id)
        => await Mediator.Send(new DeleteGardener {Id = id});
}
