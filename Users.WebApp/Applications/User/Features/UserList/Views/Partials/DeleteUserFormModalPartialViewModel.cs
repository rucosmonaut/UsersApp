namespace Users.WebApp.Applications.User.Features.UserList.Views.Partials;

public class DeleteUserFormModalPartialViewModel
{
    public DeleteUserFormModalPartialViewModel(
        string deleteUserActionUrl)
    {
        this.DeleteUserActionUrl = deleteUserActionUrl;
    }

    public string DeleteUserActionUrl { get; }
}
