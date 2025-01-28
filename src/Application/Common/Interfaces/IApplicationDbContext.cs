using data_visualization_api.Domain.Entities;

namespace data_visualization_api.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Indicator> Indicators { get; }

    DbSet<Topic> Topics { get; }

    DbSet<Area> Areas { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
