namespace Users.WebApp.Configuration;

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
