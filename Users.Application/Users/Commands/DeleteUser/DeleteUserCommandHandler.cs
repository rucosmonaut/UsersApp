namespace Users.Application.Users.Commands.DeleteUser;

using global::Users.Application.Common.Exceptions;
using global::Users.Application.Interfaces;
using global::Users.Domain;

public class DeleteUserCommandHandler
    : IDeleteUserCommandHandler
{
    private readonly IUsersDbContext _dbContext;

    public DeleteUserCommandHandler(
        IUsersDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task HandleAsync(
        Guid id)
    {
        var userEntity = await this
            ._dbContext
            .Users
            .FindAsync(id);

        if (userEntity == null || userEntity.Id != id)
        {
            throw new NotFoundException(nameof(User), id);
        }

        this
            ._dbContext
            .Users
            .Remove(userEntity);

        this
            ._dbContext
            .SaveChanges();
    }
}
