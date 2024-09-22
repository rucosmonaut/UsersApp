namespace Users.WebApp.Applications.User.Features.UserList.Views;

using Users.WebApp.Applications.User.Features.UserList.Views.Partials;

public class ListViewModel
{
    public ListViewModel(
        CreateUserFormModalPartialViewModel createUserFormModalPartialViewModel,
        EditUserFormModalPartialViewModel editUserFormModalPartialViewModel,
        List<UserPartialViewModel> userPartialViewModelList,
        DeleteUserFormModalPartialViewModel deleteUserFormModalPartialViewModel)
    {
        this.CreateUserFormModalPartialViewModel = createUserFormModalPartialViewModel;
        this.EditUserFormModalPartialViewModel = editUserFormModalPartialViewModel;
        this.UserPartialViewModelList = userPartialViewModelList;
        this.DeleteUserFormModalPartialViewModel = deleteUserFormModalPartialViewModel;
    }

    public CreateUserFormModalPartialViewModel CreateUserFormModalPartialViewModel { get; }

    public EditUserFormModalPartialViewModel EditUserFormModalPartialViewModel { get; }

    public DeleteUserFormModalPartialViewModel DeleteUserFormModalPartialViewModel { get; }

    public List<UserPartialViewModel> UserPartialViewModelList { get; }
}
