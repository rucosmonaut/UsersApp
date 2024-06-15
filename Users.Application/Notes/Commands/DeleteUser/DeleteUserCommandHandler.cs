namespace Users.Application.Notes.Commands.DeleteUser;

using Users.Application.Common.Exceptions;
using Users.Application.Interfaces;
using Users.Domain;

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
        var userEntity = await _dbContext
            .Users
            .FindAsync(new object[] { id });

        if (userEntity == null || userEntity.Id != id)
        {
            throw new NotFoundException(nameof(User), id);
        }

        this._dbContext.Users.Remove(userEntity);
        this._dbContext.SaveChanges();
    }
}
