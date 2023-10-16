using DigitalGarden.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Presentation;

[Route("api/[Controller]/[action]")]
public class ReviewController : Controller
{
public IMediator Mediator { get; }

    public ReviewController(IMediator mediator)
    {
        Mediator = mediator;
    }

    [HttpGet("{plantRecordId}")]
    public async Task<IActionResult> GetReviews([FromQuery] int plantRecordId) 
        => await Mediator.Send(new GetReviews{ PlantRecordId = plantRecordId});

    [HttpGet("{id}/{plantRecordId}")]
    public async Task<IActionResult> GetReview([FromQuery] int id, [FromQuery] int plantRecordId)
        => await Mediator.Send(new GetReviews {Id = id,  PlantRecordId= plantRecordId});

    [HttpPost]
    public async Task<IActionResult> CreateReview([FromBody] ReviewModel model)
        => await Mediator.Send(new CreateReview {Model = model});

    [HttpPut("{id}/{plantRecordId}")]
    public async Task<IActionResult> UpdateReview([FromQuery] int id, [FromQuery] int plantRecordId, [FromBody] ReviewModel model)
        => await Mediator.Send(new UpdateReview {Id = id, PlantRecordId = plantRecordId, ReviewModel = model});

    [HttpDelete("{id}/{plantRecordId}")]
    public async Task<IActionResult> DeleteReview([FromQuery] int id, [FromQuery] int plantRecordId)
        => await Mediator.Send(new DeleteReview {Id = id, PlantRecordId = plantRecordId});
}
