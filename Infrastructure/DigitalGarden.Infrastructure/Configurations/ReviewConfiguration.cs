using DigitalGarden.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalGarden.Infrastructure;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    void IEntityTypeConfiguration<Review>.Configure(EntityTypeBuilder<Review> builder)
    {
        builder
        .HasOne(r => r.PlantRecord)
        .WithMany(r => r.PlantReviews)
        .HasForeignKey(r => r.PlantRecordId);

        builder.Property(p => p.Note).HasMaxLength(250);
    }
}
