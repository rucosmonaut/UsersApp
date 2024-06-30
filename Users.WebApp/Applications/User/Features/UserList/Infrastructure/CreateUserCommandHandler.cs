namespace Users.WebApp.Applications.User.Features.UserList.Infrastructure;

using OneOf;
using Users.Domain;

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
            string email,
            List<Profession> professionList)
    {
        var userId = await createUserCommandHandler.HandleAsync(
            email: email,
            professionList: professionList);

        return new ICreateUserCommandHandler.AddedResult(userId);
    }
}
