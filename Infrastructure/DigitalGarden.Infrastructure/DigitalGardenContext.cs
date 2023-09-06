using DigitalGarden.Domain;
using Microsoft.EntityFrameworkCore;

namespace DigitalGarden.Infrastructure;

public class DigitalGardenContext : BaseDigitalGardenContext
{
    public DigitalGardenContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DigitalGardenContext).Assembly);
    }
}
