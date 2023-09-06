using DigitalGarden.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalGarden.Infrastructure;

public class MaintenanceConfiguration : IEntityTypeConfiguration<MaintenanceTask>
{
    void IEntityTypeConfiguration<MaintenanceTask>.Configure(EntityTypeBuilder<MaintenanceTask> builder)
    {
        builder
        .HasOne(m => m.Garden)
        .WithMany(m => m.Maintenances)
        .HasForeignKey(m => m.GardenId);

        builder
        .HasOne(m => m.Plant)
        .WithMany(m => m.Maintenances)
        .HasForeignKey(m => m.PlantId);

        builder.Property(p => p.Description).HasMaxLength(200);
    }
}
