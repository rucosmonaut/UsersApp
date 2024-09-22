namespace Users.WebApp.Applications.User;

using Users.WebApp.Applications.User.Features.UserList;

public static class ApplicationIocConfig
{
    public static void Configure(
        IServiceCollection services)
    {
        IocConfig.Configure(
            services: services);
    }
}
