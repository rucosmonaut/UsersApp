namespace Users.Application.Users.Queries.GetUserList;

public interface IGetUserListQueryHandler
{
    Task<UserListVm> HandleAsync();
}
