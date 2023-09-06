using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class CreatePlant : IRequest<IActionResult>
{
    public required PlantModel Model {get; set;}
}

public class CreatePlantHandler : IRequestHandler<CreatePlant, IActionResult>
{
    public CreatePlantHandler(BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get;}
    Task<IActionResult> IRequestHandler<CreatePlant, IActionResult>.Handle(CreatePlant request, CancellationToken cancellationToken)
    {
        var plant = new Plant {
            CommonName = request.Model.CommonName, 
            ScientificName = request.Model.ScientificName,
            GardenId = request.Model.GardenId,
            Garden = request.Model.Garden,
            Description = request.Model.Description,
            Maintenances = request.Model.Maintenances,
            PlantingSeason = request.Model.PlantingSeason,
            PlantRecords = request.Model.PlantRecords,
            PlantType = request.Model.PlantType,
            SoilTypePreference = request.Model.SoilTypePreference,
            SunlightRequirement = request.Model.SunlightRequirement,
            WateringFrequency = request.Model.WateringFrequency,
            GrowthCycle = request.Model.GrowthCycle
            };

            BaseContext.Add(plant);
            return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Plant Saved Succesfully") as IActionResult
                : new BadRequestObjectResult("Plant cannot be Saved") as IActionResult);

    }
}