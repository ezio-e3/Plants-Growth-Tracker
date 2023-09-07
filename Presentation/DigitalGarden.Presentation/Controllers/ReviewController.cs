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

    [HttpGet]
    public async Task<IActionResult> GetAllReviews([FromQuery] PlantRecordModel plantRecordModel) 
        => await Mediator.Send(new GetReviews{ PlantRecordModel = plantRecordModel});

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGardener([FromQuery] int id, [FromQuery] PlantRecordModel plantRecordModel)
        => await Mediator.Send(new GetReviews {Id = id,  PlantRecordModel= plantRecordModel});

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReviewModel model)
        => await Mediator.Send(new CreateReview {Model = model});
}
