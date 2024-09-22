namespace Users.Application.Interfaces;

using global::Users.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public interface IUsersDbContext
{
    DbSet<User> Users { get; set; }

    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    EntityEntry<TEntity> Entry<TEntity>(
        TEntity entity)
        where TEntity : class;
}
