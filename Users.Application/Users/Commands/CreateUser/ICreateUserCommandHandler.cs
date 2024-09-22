namespace Users.Application.Users.Commands.CreateUser;

using global::Users.Domain;

public interface ICreateUserCommandHandler
{
    Task<Guid> HandleAsync(
        string email,
        List<Profession> professionList);
}
