namespace Users.WebApp.Applications.User.Features.UserList.Infrastructure;

using OneOf;

internal class DeleteUserCommandHandler
    : IDeleteUserCommandHandler
{
    private readonly Application.Notes.Commands.DeleteUser.IDeleteUserCommandHandler deleteUserCommandHandler;

    public DeleteUserCommandHandler(
        Application.Notes.Commands.DeleteUser.IDeleteUserCommandHandler deleteUserCommandHandler)
    {
        this.deleteUserCommandHandler = deleteUserCommandHandler;
    }

    public async Task<
            OneOf<
                IDeleteUserCommandHandler.DeletedResult,
                IDeleteUserCommandHandler.NotFoundResult>>
        HandleAsync(
            string userId)
    {
        await this
            .deleteUserCommandHandler
            .HandleAsync(Guid.Parse(userId));

        return new IDeleteUserCommandHandler.DeletedResult();
    }
}
