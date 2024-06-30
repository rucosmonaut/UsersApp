namespace Users.WebApp.Applications.User.Features.UserList.Adapters.InfrastructureContract;

using Users.Domain;

public interface IUserListQueryHandler
{
    Task<List<User>> HandleAsync(
        string partnerId);
}
