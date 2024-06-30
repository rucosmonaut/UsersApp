namespace Users.WebApp.Applications.User.Features.UserList;

using Users.WebApp.Applications.User.Features.UserList.Actions.ViewList;
using Users.WebApp.Applications.User.Features.UserList.Adapters;
using Users.WebApp.Applications.User.Features.UserList.Infrastructure;

internal class IocConfig
{
    public static void Configure(
        IServiceCollection services)
    {
        services.AddSingleton<IViewListActionModelQueryHandler>(
            implementationInstance: new ViewListActionModelQueryHandler());

        services.AddSingleton<ICreateUserCommandHandler>(
            implementationInstance: new CreateUserCommandHandler());
    }
}
