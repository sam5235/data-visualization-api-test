using System.Runtime.InteropServices;
using data_visualization_api.Domain.Constants;
using data_visualization_api.Domain.Entities;
using data_visualization_api.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace data_visualization_api.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

        // Default data
        // Seed, if necessary
        if (!_context.TodoLists.Any())
        {
            _context.TodoLists.Add(new TodoList
            {
                Title = "Todo List",
                Items =
                {
                    new TodoItem { Title = "Make a todo list 📃" },
                    new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
            });

            await _context.SaveChangesAsync();
        }

        //Seed Indicators
        if (!_context.Indicators.Any())
        {
            _context.Indicators.Add(new Indicator
            {
                RootIndicatorId = 1,
                ShortNameEn = "Sample EN",
                ShortNameFr = "Sample FR",
                NameEn = "Sample EN",
                NameFr = "Sample FR",
                DescriptionEn = "Sample EN",
                DescriptionFr = "Sample FR",
                ModeEn = "Sample EN",
                ModeFr = "Sample FR",
                UnitEn = "Sample EN",
                UnitFr = "Sample FR",
                ScaleEn = "Sample EN",
                ScaleFr = "Sample FR",
                Multiplier = 1.0,
                RoundLevel = 1,
                TopicIds = [1, 2, 3],
                Created = DateTimeOffset.Now,
                CreatedBy = "Administrator",
                LastModified = DateTimeOffset.Now,
                LastModifiedBy = "Administrator"
            });

            await _context.SaveChangesAsync();
        }

        //Seed Topics
        if (!_context.Topics.Any())
        {
            _context.Topics.AddRange(
            new Topic
            {
                TopicCode = "T001",
                TopicEn = "Economy",
                TopicFr = "Économie",
                DescriptionEn = "Topics related to economic indicators.",
                DescriptionFr = "Sujets liés aux indicateurs économiques.",
                MainTopicEn = "Economic Indicators",
                MainTopicFr = "Indicateurs économiques",
                Order = 1,
                RootIndicatorIds = new[] { 101, 102 },
                Created = DateTimeOffset.Now,
                CreatedBy = "Administrator",
                LastModified = DateTimeOffset.Now,
                LastModifiedBy = "Administrator"
            },
            new Topic
            {
                TopicCode = "T002",
                TopicEn = "Health",
                TopicFr = "Santé",
                DescriptionEn = "Topics related to health indicators.",
                DescriptionFr = "Sujets liés aux indicateurs de santé.",
                MainTopicEn = "Health Indicators",
                MainTopicFr = "Indicateurs de santé",
                Order = 2,
                RootIndicatorIds = new[] { 201, 202 },
                Created = DateTimeOffset.Now,
                CreatedBy = "Administrator",
                LastModified = DateTimeOffset.Now,
                LastModifiedBy = "Administrator"
            });

            await _context.SaveChangesAsync();
        }

        //Seed Areas Data
        if (!_context.Areas.Any())
        {
            _context.Areas.AddRange(
            new Area
            {
                AreaCode = "001",
                NameEn = "Global",
                NameFr = "Mondial",
                Iso3 = null,
                Created = DateTimeOffset.Now,
                CreatedBy = "Administrator",
                LastModified = DateTimeOffset.Now,
                LastModifiedBy = "Administrator"
            },
            new Area
            {
                AreaCode = "US",
                NameEn = "United States",
                NameFr = "États-Unis",
                Iso3 = "USA",
                Created = DateTimeOffset.Now,
                CreatedBy = "Administrator",
                LastModified = DateTimeOffset.Now,
                LastModifiedBy = "Administrator"
            });

            await _context.SaveChangesAsync();
        }

    }
}
