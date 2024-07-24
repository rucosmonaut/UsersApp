namespace Users.Application.Users.Queries.GetUserList;

public class UserListVm
{
    public UserListVm(
        IList<UserLookupDto> users)
    {
        this.Users = users;
    }

    public IList<UserLookupDto> Users { get; set; } = default!;
}
