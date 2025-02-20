using data_visualization_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data_visualization_api.Infrastructure.Data.Configurations;
public class EdgeTimeSeriesDataConfiguration : IEntityTypeConfiguration<EdgeTimeSeriesData>
{
  public void Configure(EntityTypeBuilder<EdgeTimeSeriesData> builder)
  {
    builder.HasKey(e => e.Id);
    builder.Property(e => e.CountryId).IsRequired();
    builder.Property(e => e.CountryName).IsRequired();

    // Relationship to TimeSeriesData
    builder.HasMany(e => e.YearData)
        .WithOne(t => t.EdgeTimeSeriesData)
        .HasForeignKey(t => t.EdgeTimeSeriesDataId);
  }
}
