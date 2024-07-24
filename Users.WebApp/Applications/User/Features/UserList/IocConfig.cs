namespace Users.WebApp.Applications.User.Features.UserList;

using Users.Application.Interfaces;
using Users.Application.Users.Commands.UpdateUser;
using Users.Application.Users.Queries.GetUserList;
using Users.WebApp.Applications.User.Features.UserList.Actions.ViewList;
using Users.WebApp.Applications.User.Features.UserList.Adapters;
using Users.WebApp.Applications.User.Features.UserList.Infrastructure;

internal static class IocConfig
{
    public static void Configure(
        IServiceCollection services)
    {
        services.AddSingleton<IViewListActionModelQueryHandler>(
            implementationInstance: new ViewListActionModelQueryHandler(
                new UserListQueryHandler(
                    new GetUserListQueryHandler(
                        dbContext: services
                            .BuildServiceProvider()
                            .GetRequiredService<IUsersDbContext>()))));

        services.AddSingleton<ICreateUserCommandHandler>(
            implementationInstance: new CreateUserCommandHandler(
                createUserCommandHandler: new Application.Users.Commands.CreateUser.CreateUserCommandHandler(
                    dbContext: services
                        .BuildServiceProvider()
                        .GetRequiredService<IUsersDbContext>())));

        services.AddSingleton<IEditSenderCommandHandler>(
            implementationInstance: new EditSenderCommandHandler(
                updateUserCommandHandler: new UpdateUserCommandHandler(
                    dbContext: services
                        .BuildServiceProvider()
                        .GetRequiredService<IUsersDbContext>())));

        services.AddSingleton<IDeleteUserCommandHandler>(
            implementationInstance: new DeleteUserCommandHandler(
                new Application.Users.Commands.DeleteUser.DeleteUserCommandHandler(
                    dbContext: services
                        .BuildServiceProvider()
                        .GetRequiredService<IUsersDbContext>())));
    }
}
