namespace Users.Application.Notes.Commands.CreateUser;

using Users.Domain;

public interface ICreateUserCommandHandler
{
    Task<Guid> HandleAsync(
        string email,
        List<Profession> professionList);
}
