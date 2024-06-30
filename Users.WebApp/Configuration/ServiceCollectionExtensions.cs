namespace Users.WebApp.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigurePartnerOfficeServices(
        this IServiceCollection services)
    {
        services.ConfigureGlobal();

        return services;
    }
}
