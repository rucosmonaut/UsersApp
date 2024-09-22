namespace Users.WebApp.Applications.User.Features.UserList.Actions.DeleteUser;

using System.ComponentModel.DataAnnotations;

public class DeleteUserRequestModel
{
    [Required]
    public required string Id { get; init; }
}
