namespace Users.Application.Users.Commands.DeleteUser;

public interface IDeleteUserCommandHandler
{
    Task HandleAsync(
        Guid id);
}
