namespace Users.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Users.Application.Interfaces;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = "Data Source=Users.db";

        services.AddDbContext<UsersDbContext>(options =>
        {
            //options.UseSqlite(connectionString);
            options.UseInMemoryDatabase("Users");
        });

        services.AddScoped<IUsersDbContext>(provider =>
            provider.GetService<UsersDbContext>()!);

        return services;
    }
}
