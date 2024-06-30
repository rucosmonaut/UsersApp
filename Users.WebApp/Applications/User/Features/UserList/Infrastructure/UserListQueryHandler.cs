namespace Users.WebApp.Applications.User.Features.UserList.Infrastructure;

using Users.Domain;
using Users.WebApp.Applications.User.Features.UserList.Adapters.InfrastructureContract;

internal class UserListQueryHandler
    : IUserListQueryHandler
{
    public Task<List<User>> HandleAsync(
        string partnerId)
    {
        throw new NotImplementedException();
    }
}
