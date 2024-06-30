namespace Users.WebApp.Applications.User.Features.UserList.Views;

using Users.WebApp.Applications.User.Features.UserList.Views.Partials;

public class ListViewModel
{
    public ListViewModel(
        CreateUserFormModalPartialViewModel createUserFormModalPartialViewModel,
        List<UserPartialViewModel> userList)
    {
        this.CreateUserFormModalPartialViewModel = createUserFormModalPartialViewModel;
        this.UserList = userList;
    }

    public CreateUserFormModalPartialViewModel CreateUserFormModalPartialViewModel { get; }

    public List<UserPartialViewModel> UserList { get; }
}
