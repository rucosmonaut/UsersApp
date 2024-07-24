namespace Users.WebApp.Applications.User.Features.UserList.Actions.EditUser;

using System.ComponentModel.DataAnnotations;

public class EditUserRequestModel
{
    [Required]
    public string Id { get; set; } = default!;

    [Required]
    public string Email { get; set; } = default!;
}
