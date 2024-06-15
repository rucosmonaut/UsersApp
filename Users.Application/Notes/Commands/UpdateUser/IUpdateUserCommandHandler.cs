namespace Users.Application.Notes.Commands.UpdateUser;

using Users.Domain;

public interface IUpdateUserCommandHandler
{
    Task HandleAsync(
        Guid id,
        string email,
        List<Profession> professionList);
}
