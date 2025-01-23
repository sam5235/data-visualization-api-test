using data_visualization_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace data_visualization_api.Infrastructure.Data.Configurations;

public class IndicatorConfiguration : IEntityTypeConfiguration<Indicator>
{
    public void Configure(EntityTypeBuilder<Indicator> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.ShortNameEn)
                    .HasMaxLength(255)
                    .IsRequired();

        builder.Property(i => i.ShortNameFr)
            .HasMaxLength(255);

        builder.Property(i => i.TopicIds)
            .HasConversion(
                v => string.Join(",", v), // Convert int[] to CSV string for storage
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()
            ).Metadata.SetValueComparer(new ValueComparer<int[]>(
                (c1, c2) => (c1 != null && c2 != null) && c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToArray()));

        // builder.Property(i => i.ThemeIndicatorIds)
        //     .HasConversion(
        //         v => string.Join(",", v),
        //         v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()
        //     );
    }
}