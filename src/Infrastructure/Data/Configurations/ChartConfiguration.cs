using data_visualization_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data_visualization_api.Infrastructure.Data.Configurations;

public class ChartConfiguration : IEntityTypeConfiguration<Chart>
{
    public void Configure(EntityTypeBuilder<Chart> builder)
    {
        // Configure the base properties
        builder.Property(c => c.SelectedChartType).IsRequired();
        builder.Property(c => c.SelectedIndicatorName).IsRequired();
        builder.Property(c => c.Thumbnail).IsRequired();
        builder.Property(c => c.XAxisLabel).IsRequired();
        builder.Property(c => c.YAxisLabel).IsRequired();
        builder.Property(c => c.ChartTitle).IsRequired();

        builder.OwnsOne(c => c.LegendOptions, lo => lo.ToJson());
        builder.OwnsMany(c => c.SelectedTopics, st => st.ToJson());
        builder.OwnsMany(c => c.SelectedIndicators, si => si.ToJson());
        builder.OwnsMany(c => c.SelectedCountriesData, cd =>
        {
            cd.ToJson();
            // cd.OwnsMany(country => country.YearData);
            cd.Property(c => c.YearDataJson).HasColumnName("YearData");
        });
    }
}