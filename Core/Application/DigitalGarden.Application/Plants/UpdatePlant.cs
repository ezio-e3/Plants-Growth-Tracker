using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class UpdatePlant : IRequest<IActionResult>
{
    public required PlantModel plantModel {get; set;}
}
public class UpdatePlantHandler : IRequestHandler<UpdatePlant, IActionResult>
{
    public UpdatePlantHandler (BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get;}
    Task<IActionResult> IRequestHandler<UpdatePlant, IActionResult>.Handle(UpdatePlant request, CancellationToken cancellationToken)
    {
        var plant = BaseContext.Plants.Where(p => p.Id ==request.plantModel.Id).FirstOrDefault();
        if(plant == null)
            return Task.FromResult(new BadRequestObjectResult("Plant cannot be found") as IActionResult);
        plant.CommonName = request.plantModel.CommonName;
        plant.ScientificName = request.plantModel.ScientificName;
        plant.PlantType = request.plantModel.PlantType;
        plant.GrowthCycle = request.plantModel.GrowthCycle;
        plant.Maintenances = request.plantModel.Maintenances;
        plant.Garden = request.plantModel.Garden;
        plant.GardenId = request.plantModel.GardenId;
        plant.PlantRecords = request.plantModel.PlantRecords;
        plant.Description = request.plantModel.Description;
        plant.SoilTypePreference = request.plantModel.SoilTypePreference;
        plant.WateringFrequency = request.plantModel.WateringFrequency;
        plant.SunlightRequirement = request.plantModel.SunlightRequirement;
        plant.PlantingSeason = request.plantModel.PlantingSeason;
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Plant updated succesfully") as IActionResult 
            : new BadRequestObjectResult("Unable to update Plant") as IActionResult);
    }
}
