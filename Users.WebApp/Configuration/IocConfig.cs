namespace Users.WebApp.Configuration;

using Microsoft.EntityFrameworkCore;
using Users.Application.Interfaces;
using Users.Persistence;

public static class IocConfig
{
    public static void ConfigureGlobal(
        this IServiceCollection services)
    {
        const string UsersDbConnectionString ="Data Source=UsersDB.sqlite;";

        services.AddTransient<IUsersDbContext>(
            provider => new UsersDbContext(
                options: new DbContextOptionsBuilder<UsersDbContext>()
                    .UseSqlite(UsersDbConnectionString)
                    .Options));


        Applications
            .User
            .ApplicationIocConfig
            .Configure(services);
    }
}

