namespace Users.Application.Users.Commands.UpdateUser;

using global::Users.Domain;

public interface IUpdateUserCommandHandler
{
    Task HandleAsync(
        Guid id,
        string email,
        List<Profession> professionList);
}
