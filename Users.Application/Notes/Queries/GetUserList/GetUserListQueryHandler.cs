namespace Users.Application.Notes.Queries.GetUserList;

using Users.Application.Interfaces;

public class GetUserListQueryHandler
    : IGetUserListQueryHandler
{
    private readonly IUsersDbContext _dbContext;

    public GetUserListQueryHandler(
        IUsersDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public Task<UserListVm> HandleAsync()
    {
        var userList = this
            ._dbContext
            .Users
            .ToList()
            .Select(user => new UserLookupDto(
                id: user.Id,
                email: user.Email,
                professionList: user.ProfessionList,
                creationDate: user.CreationDate,
                editDate: user.EditDate,
                deletedDate: user.DeletedDate))
            .ToList();

        return Task.FromResult(
            result: new UserListVm(
                users: userList));
    }
}
