using DigitalGarden.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGarden.Presentation;

[Route("api/[Controller]")]
public class PlantController : Controller
{
    public IMediator Mediator { get; }

    public PlantController(IMediator mediator)
    {
        Mediator = mediator;
    }

     [HttpGet]
    public async Task<IActionResult> GetAllPlants([FromQuery] GardenModel gardenModel) 
        => await Mediator.Send(new GetPlants{Garden = gardenModel});

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGardener([FromQuery] int id, [FromQuery] GardenModel gardenModel)
        => await Mediator.Send(new GetPlants {Id = id, Garden = gardenModel});

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PlantModel model)
        => await Mediator.Send(new CreatePlant {Model = model});

}
