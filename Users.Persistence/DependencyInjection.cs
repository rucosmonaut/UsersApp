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
        var сonnectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");

        var mongoDbClient = new MongoClient(
            new MongoClientSettings
            {
                Server = new MongoServerAddress(сonnectionString)
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
