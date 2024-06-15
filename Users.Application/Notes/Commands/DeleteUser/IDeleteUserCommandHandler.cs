namespace Users.Application.Notes.Commands.DeleteUser;

public interface IDeleteUserCommandHandler
{
    Task HandleAsync(
        Guid id);
}
