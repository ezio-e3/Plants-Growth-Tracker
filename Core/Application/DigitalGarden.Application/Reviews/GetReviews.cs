using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class GetReviews : IRequest<IActionResult>
{
public int? Id {get; set;}

public required int PlantRecordId {get; set;}

}
public class GetReviewsHandler : IRequestHandler<GetReviews, IActionResult>{
    public GetReviewsHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get; set;}

    public Task<IActionResult> Handle(GetReviews request, CancellationToken cancellationToken)
    {
         if(request.Id == null){
            var reviews = BaseContext.Reviews.Where(p => p.PlantRecordId == request.PlantRecordId).ToList();
            return Task.FromResult(new OkObjectResult(reviews) as IActionResult);
        }

        var review = BaseContext.Reviews.Where(p => request.Id == p.Id &&
        request.PlantRecordId == p.PlantRecordId).FirstOrDefault();
        return Task.FromResult(review == null ? new BadRequestResult() as IActionResult
            : new OkObjectResult(review) as IActionResult);
    }
}
