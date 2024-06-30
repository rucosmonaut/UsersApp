namespace Users.WebApp.Applications.User.Features.UserList.Actions.CreateUser;

using System.ComponentModel.DataAnnotations;
using Users.Domain;

public class CreateUserRequestModel
{
    [Required]
    public string Email { get; set; } = default!;

    [Required]
    public List<Profession> Professions { get; set; } = default!;
}
