namespace Users.WebApp.Applications.User.Features.UserList.Infrastructure;

using Users.Application.Users.Queries.GetUserList;
using Users.Domain;
using Users.WebApp.Applications.User.Features.UserList.Adapters.InfrastructureContract;

internal class UserListQueryHandler
    : IUserListQueryHandler
{
    private readonly IGetUserListQueryHandler getUserListQueryHandler;

    public UserListQueryHandler(
        IGetUserListQueryHandler getUserListQueryHandler)
    {
        this.getUserListQueryHandler = getUserListQueryHandler;
    }

    public async Task<List<User>> HandleAsync()
    {
        return (await getUserListQueryHandler.HandleAsync())
            .Users
            .Select(
                selector: userVm => new User
                {
                    Id = userVm.Id,
                    CreationDate = userVm.CreationDate,
                    DeletedDate = userVm.DeletedDate,
                    EditDate = userVm.EditDate,
                    Email = userVm.Email,
                    ProfessionList = userVm.ProfessionList
                })
            .ToList();
    }
}
