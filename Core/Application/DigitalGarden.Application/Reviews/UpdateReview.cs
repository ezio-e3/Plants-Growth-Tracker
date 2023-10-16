using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class UpdateReview : IRequest<IActionResult>
{
    public required int Id {get; set;}
    public required int PlantRecordId {get; set;}
    public required ReviewModel ReviewModel {get; set;}
}
public class UpdateReviewTaskHandler : IRequestHandler<UpdateReview, IActionResult>{
    public UpdateReviewTaskHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get; set;}

    public Task<IActionResult> Handle(UpdateReview request, CancellationToken cancellationToken)
    {
        var review = BaseContext.Reviews.Where(m => m.Id == request.Id && m.PlantRecordId == request.PlantRecordId).FirstOrDefault();
        if(review == null)
            return Task.FromResult(new BadRequestObjectResult("Review does not exist") as IActionResult);
        review.Note = request.ReviewModel.Note;
        review.ReviewTime = request.ReviewModel.ReviewTime;
        review.GrowthStage = request.ReviewModel.GrowthStage;
        review.PlantRecord = request.ReviewModel.PlantRecord;
        review.PlantRecordId = request.ReviewModel.PlantRecordId;
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Review updated succesfully") as IActionResult 
            : new BadRequestObjectResult("Unable to update review") as IActionResult);
    }
}
