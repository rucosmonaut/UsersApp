namespace Users.Application.Interfaces;

using global::Users.Domain;
using Microsoft.EntityFrameworkCore;

public interface IUsersDbContext
{
    DbSet<User> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    int SaveChanges();
}
