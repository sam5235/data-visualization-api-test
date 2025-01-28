using data_visualization_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace data_visualization_api.Infrastructure.Data.Configurations
{
  public class TopicConfiguration : IEntityTypeConfiguration<Topic>
  {
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
      builder.HasKey(t => t.Id);

      // builder.Property(t => t.TopicCode)
      //   .HasMaxLength(100)
      //   .IsRequired();

      // builder.Property(t => t.TopicFr)
      //     .HasMaxLength(255);

      // builder.Property(t => t.DescriptionEn)
      //     .HasMaxLength(1000);

      // builder.Property(t => t.DescriptionFr)
      //     .HasMaxLength(1000);

      // builder.Property(t => t.MainTopicEn)
      //     .HasMaxLength(255);

      // builder.Property(t => t.MainTopicFr)
      //     .HasMaxLength(255);

      // builder.Property(t => t.Order)
      //     .IsRequired();

      // builder.Property(t => t.RootIndicatorIds)
      // .HasConversion(
      //   v => string.Join(",", v), // Convert int[] to CSV string for storage
      //   v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()
      // ).Metadata.SetValueComparer(new ValueComparer<int[]>(
      //   (c1, c2) => (c1 != null && c2 != null) && c1.SequenceEqual(c2),
      //   c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
      //   c => c.ToArray()));
    }
  }
}