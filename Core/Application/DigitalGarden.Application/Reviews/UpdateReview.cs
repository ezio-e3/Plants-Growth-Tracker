using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class UpdateReview : IRequest<IActionResult>
{
    public required ReviewModel reviewModel {get; set;}
}
public class UpdateReviewTaskHandler : IRequestHandler<UpdateReview, IActionResult>{
    public UpdateReviewTaskHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get; set;}

    public Task<IActionResult> Handle(UpdateReview request, CancellationToken cancellationToken)
    {
        var review = BaseContext.Reviews.Where(m => m.Id == request.reviewModel.Id).FirstOrDefault();
        if(review == null)
            return Task.FromResult(new BadRequestObjectResult("Review does not exist") as IActionResult);
        review.Note = request.reviewModel.Note;
        review.ReviewTime = request.reviewModel.ReviewTime;
        review.GrowthStage = request.reviewModel.GrowthStage;
        review.PlantRecord = request.reviewModel.PlantRecord;
        review.PlantRecordId = request.reviewModel.PlantRecordId;
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Review updated succesfully") as IActionResult 
            : new BadRequestObjectResult("Unable to update review") as IActionResult);
    }
}
