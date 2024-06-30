namespace Users.WebApp.Applications.User.Features.UserList.Views.Partials;

public sealed class CreateUserFormModalPartialViewModel
{
    public CreateUserFormModalPartialViewModel(
        string createUserActionUrl)
    {
        this.CreateUserActionUrl = createUserActionUrl;
    }

    public string CreateUserActionUrl { get; }
}
