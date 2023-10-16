using DigitalGarden.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Application;

public class UpdatePlant : IRequest<IActionResult>
{
    public required int Id {get; set;}
    public required int GardenId {get; set;}
    public required PlantModel PlantModel {get; set;}
}
public class UpdatePlantHandler : IRequestHandler<UpdatePlant, IActionResult>
{
    public UpdatePlantHandler (BaseDigitalGardenContext baseDigitalGardenContext){
        BaseContext = baseDigitalGardenContext;
    }
    public BaseDigitalGardenContext BaseContext {get;}
    Task<IActionResult> IRequestHandler<UpdatePlant, IActionResult>.Handle(UpdatePlant request, CancellationToken cancellationToken)
    {
        var plant = BaseContext.Plants.Where(p => p.Id ==request.Id && p.GardenId == request.GardenId).FirstOrDefault();
        if(plant == null)
            return Task.FromResult(new BadRequestObjectResult("Plant cannot be found") as IActionResult);
        plant.CommonName = request.PlantModel.CommonName;
        plant.ScientificName = request.PlantModel.ScientificName;
        plant.PlantType = request.PlantModel.PlantType;
        plant.GrowthCycle = request.PlantModel.GrowthCycle;
        plant.Maintenances = request.PlantModel.Maintenances;
        plant.Garden = request.PlantModel.Garden;
        plant.GardenId = request.PlantModel.GardenId;
        plant.PlantRecords = request.PlantModel.PlantRecords;
        plant.Description = request.PlantModel.Description;
        plant.SoilTypePreference = request.PlantModel.SoilTypePreference;
        plant.WateringFrequency = request.PlantModel.WateringFrequency;
        plant.SunlightRequirement = request.PlantModel.SunlightRequirement;
        plant.PlantingSeason = request.PlantModel.PlantingSeason;
        return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Plant updated succesfully") as IActionResult 
            : new BadRequestObjectResult("Unable to update Plant") as IActionResult);
    }
}
