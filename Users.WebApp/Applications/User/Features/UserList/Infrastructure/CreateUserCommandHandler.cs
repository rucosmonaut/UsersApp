namespace Users.WebApp.Applications.User.Features.UserList.Infrastructure;

using OneOf;
using Users.Domain;
using Users.WebApp.Applications.User.Features.UserList.Infrastructure.Helpers;

internal class CreateUserCommandHandler
    : ICreateUserCommandHandler
{
    private readonly Users.Application.Notes.Commands.CreateUser.ICreateUserCommandHandler createUserCommandHandler;

    public CreateUserCommandHandler(
        Application.Notes.Commands.CreateUser.ICreateUserCommandHandler createUserCommandHandler)
    {
        this.createUserCommandHandler = createUserCommandHandler;
    }

    public async Task<
            OneOf<
                ICreateUserCommandHandler.AddedResult,
                ICreateUserCommandHandler.AlreadyExistsResult>>
        HandleAsync(
            string email)
    {


        var userId = await createUserCommandHandler.HandleAsync(
            email: email,
            professionList: ProffesionBuilder.BuildProfessionList());

        return new ICreateUserCommandHandler.AddedResult(userId);
    }
}
