namespace Users.Application.Users.Commands.CreateUser;

using global::Users.Application.Interfaces;
using global::Users.Domain;

public class CreateUserCommandHandler
    : ICreateUserCommandHandler
{
    private readonly IUsersDbContext _dbContext;

    public CreateUserCommandHandler(
        IUsersDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<Guid> HandleAsync(
        string email,
        List<Profession> professionList)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            ProfessionList = professionList,
            CreationDate = DateTime.UtcNow,
            DeletedDate = null,
            EditDate = null
        };

        await this
            ._dbContext
            .Users
            .AddAsync(user);

        this._dbContext.SaveChanges();

        return user.Id;
    }
}
