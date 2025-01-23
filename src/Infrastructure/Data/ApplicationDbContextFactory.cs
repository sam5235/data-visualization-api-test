using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace data_visualization_api.Infrastructure.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
  public ApplicationDbContext CreateDbContext(string[] args)
  {
    // Build configuration from appsettings.json
    IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.Development.json") // Use the appropriate appsettings file
        .Build();

    var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
    builder.UseSqlServer(
        configuration.GetConnectionString("DefaultConnection"), // Match your config key
        optionsBuilder =>
            optionsBuilder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name));

    return new ApplicationDbContext(builder.Options);
  }
}
