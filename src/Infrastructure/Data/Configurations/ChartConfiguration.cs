using data_visualization_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data_visualization_api.Infrastructure.Data.Configurations;

public class ChartConfiguration : IEntityTypeConfiguration<Chart>
{
  public void Configure(EntityTypeBuilder<Chart> builder)
  {
    builder.HasKey(c => c.Id);

    builder.Property(c => c.SelectedChartType)
        .HasMaxLength(50)
        .IsRequired();

    builder.Property(c => c.SelectedIndicatorName)
        .HasMaxLength(255);

    builder.Property(c => c.Thumbnail)
        .IsRequired();

    builder.Property(c => c.LegendOptions)
        .HasMaxLength(1000);

    builder.Property(c => c.ChartTitle)
        .HasMaxLength(200)
        .IsRequired();

    builder.Property(c => c.XAxisLabel)
        .HasMaxLength(100);

    builder.Property(c => c.YAxisLabel)
        .HasMaxLength(100);

    // Configure relationships (if needed)
    builder.HasMany(c => c.SelectedIndicators)
        .WithMany()
        .UsingEntity(j => j.ToTable("ChartIndicators"));

    builder.HasMany(c => c.SelectedTopics)
        .WithMany()
        .UsingEntity(j => j.ToTable("ChartTopics"));
  }
}