namespace Users.WebApp.Applications.User.Features.UserList.Views;

using Users.WebApp.Applications.User.Features.UserList.Views.Partials;

public sealed class EmptyListViewModel
{
    public EmptyListViewModel(
        CreateUserFormModalPartialViewModel createUserFormModalPartialViewModel)
    {
        this.CreateUserFormModalPartialViewModel = createUserFormModalPartialViewModel;
    }

    public CreateUserFormModalPartialViewModel CreateUserFormModalPartialViewModel { get; }
}
