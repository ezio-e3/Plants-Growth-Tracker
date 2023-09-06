using DigitalGarden.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalGarden.Infrastructure;

public class PlantConfiguration : IEntityTypeConfiguration<Plant>
{
    void IEntityTypeConfiguration<Plant>.Configure(EntityTypeBuilder<Plant> builder)
    {
        builder
        .HasOne(p => p.Garden)
        .WithMany(p => p.Plants)
        .HasForeignKey(p => p.GardenId);

        builder.Property(p => p.ScientificName).HasMaxLength(150);
        builder.Property(p => p.CommonName).HasMaxLength(150);
        builder.Property(p => p.Description).HasMaxLength(250);
    }
}
