namespace Users.Application.Users.Commands.DeleteAllUsers;

using global::Users.Application.Interfaces;

public class DeleteAllUsersCommandHandler
    : IDeleteAllUsersCommandHandler
{
    private readonly IUsersDbContext _dbContext;

    public DeleteAllUsersCommandHandler(
        IUsersDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public void Handle()
    {
        this
            ._dbContext
            .Users
            .RemoveRange(
                entities: this
                    ._dbContext
                    .Users);

        this
            ._dbContext
            .SaveChanges();
    }
}
