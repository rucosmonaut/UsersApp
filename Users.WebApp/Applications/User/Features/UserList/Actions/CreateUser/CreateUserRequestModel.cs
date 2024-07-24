namespace Users.WebApp.Applications.User.Features.UserList.Actions.CreateUser;

using System.ComponentModel.DataAnnotations;

public class CreateUserRequestModel
{
    [Required]
    public string Email { get; set; } = default!;
}
