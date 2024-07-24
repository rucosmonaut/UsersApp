namespace Users.WebApp.Applications.User.Features.UserList;

using Users.Application.Interfaces;
using Users.Application.Notes.Queries.GetUserList;
using Users.WebApp.Applications.User.Features.UserList.Actions.ViewList;
using Users.WebApp.Applications.User.Features.UserList.Adapters;
using Users.WebApp.Applications.User.Features.UserList.Infrastructure;

internal class IocConfig
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
                createUserCommandHandler: new Application.Notes.Commands.CreateUser.CreateUserCommandHandler(
                    dbContext: services
                        .BuildServiceProvider()
                        .GetRequiredService<IUsersDbContext>())));

        services.AddSingleton<IEditSenderCommandHandler>(
            implementationInstance: new EditSenderCommandHandler(
                updateUserCommandHandler: new Application.Notes.Commands.UpdateUser.UpdateUserCommandHandler(
                    dbContext: services
                        .BuildServiceProvider()
                        .GetRequiredService<IUsersDbContext>())));

        services.AddSingleton<IDeleteUserCommandHandler>(
            implementationInstance: new DeleteUserCommandHandler(
                new Application.Notes.Commands.DeleteUser.DeleteUserCommandHandler(
                    dbContext: services
                        .BuildServiceProvider()
                        .GetRequiredService<IUsersDbContext>())));
    }
}
