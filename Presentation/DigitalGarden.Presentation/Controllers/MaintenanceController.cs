using DigitalGarden.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Presentation;

[Route("api/[Controller]")]
public class MaintenanceController : Controller
{
public IMediator Mediator { get; }

    public MaintenanceController(IMediator mediator)
    {
        Mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MaintenanceTaskModel model)
        => await Mediator.Send(new CreateMaintenanceTask {Model = model});
}
