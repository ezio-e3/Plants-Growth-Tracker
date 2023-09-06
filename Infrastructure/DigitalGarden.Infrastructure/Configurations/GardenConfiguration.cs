using DigitalGarden.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalGarden.Infrastructure;

public class GardenConfiguration : IEntityTypeConfiguration<Garden>
{
    void IEntityTypeConfiguration<Garden>.Configure(EntityTypeBuilder<Garden> builder)
    {
        builder
        .HasOne(g => g.Gardener)
        .WithMany(g => g.Gardens)
        .HasForeignKey(g => g.GardenerId);

        builder.Property(p => p.Name).HasMaxLength(50);
    }
}
