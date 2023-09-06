using Microsoft.EntityFrameworkCore;

namespace DigitalGarden.Domain;

public class BaseDigitalGardenContext : DbContext
{
    public DbSet<Garden> Gardens {get; set;}
    public DbSet<Gardener> Gardeners {get; set;}
    public DbSet<Plant> Plants {get; set;}
    public DbSet<PlantRecord> PlantRecords {get; set;}
    public DbSet<Review> Reviews {get; set;}
    public DbSet<MaintenanceTask> MaintenanceTasks {get; set;}

    public BaseDigitalGardenContext(DbContextOptions dbContextOptions) : base(dbContextOptions){}

}
