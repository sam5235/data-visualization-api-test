using data_visualization_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;


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
        builder.Property(c => c.SelectedIndicators).IsRequired();
        builder.Property(c => c.SelectedTopics).IsRequired();

        builder.OwnsOne(c => c.LegendOptions, lo => lo.ToJson());
        builder.OwnsMany(c => c.SelectedCountriesData, cd =>
        {
            cd.ToJson();
            cd.Property(c => c.YearData)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<Dictionary<string, int>>(v) ?? new Dictionary<string, int>()
            )
            .Metadata.SetValueComparer(new ValueComparer<Dictionary<string, int>>(
                (c1, c2) => c1 != null && c2 != null && c1.Count == c2.Count && !c1.Except(c2).Any(),
                c => c != null ? c.Aggregate(0, (hash, kv) => HashCode.Combine(hash, kv.Key.GetHashCode(), kv.Value.GetHashCode())) : 0,
                c => c != null ? new Dictionary<string, int>(c) : new Dictionary<string, int>()
        ));
        });
    }
}