namespace Users.Application.Users.Commands.UpdateUser;

using global::Users.Domain;

public interface IUpdateUserCommandHandler
{
    void Handle(
        Guid id,
        string email,
        List<Profession> professionList);
}
