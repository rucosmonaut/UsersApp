namespace Users.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Users.Application.Interfaces;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        const string ConnectionString = "localhost";

        var mongoDbClient = new MongoClient(
            new MongoClientSettings
            {
                Server = new MongoServerAddress(ConnectionString)
            });

        services.AddDbContext<UsersDbContext>(options =>
        {
            options.UseMongoDB(mongoDbClient, "Users");
        });

        services.AddScoped<IUsersDbContext>(provider =>
            provider.GetService<UsersDbContext>()!);

        return services;
    }
}
