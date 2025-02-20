using data_visualization_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data_visualization_api.Infrastructure.Data.Configurations;
public class TimeSeriesDataConfiguration : IEntityTypeConfiguration<TimeSeriesData>
{
  public void Configure(EntityTypeBuilder<TimeSeriesData> builder)
  {
    builder.HasKey(t => t.Id);
    builder.Property(t => t.Year).IsRequired();
    builder.Property(t => t.Value).IsRequired();
  }
}