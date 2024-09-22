namespace Users.WebApp.Applications.User.Features.UserList.Views.Partials;

public class UserPartialViewModel
{
    public UserPartialViewModel(
        string id,
        string email,
        string professions)
    {
        this.Id = id;
        this.Email = email;
        this.Professions = professions;
    }

    public string Id { get; }

    public string Email { get; }

    public string Professions { get; }
}
