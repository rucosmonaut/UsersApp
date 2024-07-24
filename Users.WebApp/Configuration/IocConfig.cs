namespace Users.WebApp.Configuration;

using Microsoft.EntityFrameworkCore;
using Users.Application.Interfaces;
using Users.Persistence;

public static class IocConfig
{
    public static void ConfigureGlobal(
        this IServiceCollection services)
    {
        Applications
            .User
            .ApplicationIocConfig
            .Configure(services);
    }
}

