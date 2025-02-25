using data_visualization_api.Domain.Entities;

namespace data_visualization_api.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Chart> Charts { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
