using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class CreateReview : IRequest<IActionResult>
{
    public required ReviewModel Model {get; set;}
}
public class CreateReviewHandler : IRequestHandler<CreateReview, IActionResult>
{
    public CreateReviewHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get;}

    Task<IActionResult> IRequestHandler<CreateReview, IActionResult>.Handle(CreateReview request, CancellationToken cancellationToken)
    {
                var review = new Review {
            ReviewTime = request.Model.ReviewTime,
            GrowthStage = request.Model.GrowthStage, 
            Note = request.Model.Note, 
            PlantRecord = request.Model.PlantRecord, 
            PlantRecordId = request.Model.PlantRecordId
            };
        
        BaseContext.Add(review);
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Added new review") as IActionResult
            : new BadRequestObjectResult("Could not add new review") as IActionResult);
    }
}
