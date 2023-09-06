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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PlantRecordModel model)
        => await Mediator.Send(new CreatePlantRecord {Model = model});
}
