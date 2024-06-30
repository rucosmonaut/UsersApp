namespace Users.WebApp.Applications.User.Features.UserList.Views.Partials;

public sealed class EditUserFormModalPartialViewModel
{
    public EditUserFormModalPartialViewModel(
        string editUserActionUrl,
        string email,
        string userId)
    {
        this.EditUserActionUrl = editUserActionUrl;
        this.Email = email;
        this.UserId = userId;
    }

    public string EditUserActionUrl { get; set; }


    public string Email { get; set; }

    public string UserId { get; set; }
}
