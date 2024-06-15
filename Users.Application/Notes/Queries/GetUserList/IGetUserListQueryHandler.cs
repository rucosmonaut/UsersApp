namespace Users.Application.Notes.Queries.GetUserList;

public interface IGetUserListQueryHandler
{
    Task<UserListVm> HandleAsync();
}