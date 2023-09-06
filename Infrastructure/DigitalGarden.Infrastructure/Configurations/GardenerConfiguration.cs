using DigitalGarden.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalGarden.Infrastructure;

public class GardenerConfiguration : IEntityTypeConfiguration<Gardener>
{
    void IEntityTypeConfiguration<Gardener>.Configure(EntityTypeBuilder<Gardener> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(50);
    }
}
