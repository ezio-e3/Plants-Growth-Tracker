using DigitalGarden.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalGarden.Infrastructure;

public class PlantRecordConfiguration : IEntityTypeConfiguration<PlantRecord>
{
    void IEntityTypeConfiguration<PlantRecord>.Configure(EntityTypeBuilder<PlantRecord> builder)
    {
        builder
        .HasOne(p => p.Plant)
        .WithMany(p => p.PlantRecords)
        .HasForeignKey(p => p.PlantId);
    }
}
