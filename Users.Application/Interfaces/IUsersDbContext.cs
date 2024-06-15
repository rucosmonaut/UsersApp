namespace Users.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Users.Domain;

public interface IUsersDbContext
{
    DbSet<User> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    int SaveChanges();
}
