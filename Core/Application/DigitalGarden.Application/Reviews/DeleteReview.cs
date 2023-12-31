﻿using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class DeleteReview : IRequest<IActionResult>
{
    public required int Id {get; set;}
    public required int PlantRecordId {get; set;}

}
public class DeleteReviewHandler : IRequestHandler<DeleteReview, IActionResult>{
     public DeleteReviewHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get;}

    public Task<IActionResult> Handle(DeleteReview request, CancellationToken cancellationToken)
    {
        //Fix ExecuteDelete() not working
        var review = BaseContext.Reviews.Where(r => r.Id == request.Id && r.PlantRecordId == request.PlantRecordId).FirstOrDefault();
        if (review == null)
            return Task.FromResult(new BadRequestObjectResult("Review does not exist") as IActionResult);
        BaseContext.Remove(review);
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Review deleted successfully") as IActionResult
            : new BadRequestObjectResult("Unable to delete review") as IActionResult);
    }
}
