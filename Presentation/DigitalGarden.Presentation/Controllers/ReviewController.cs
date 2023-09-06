using DigitalGarden.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Presentation;

[Route("api/[Controller]")]
public class ReviewController : Controller
{
public IMediator Mediator { get; }

    public ReviewController(IMediator mediator)
    {
        Mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReviewModel model)
        => await Mediator.Send(new CreateReview {Model = model});
}
