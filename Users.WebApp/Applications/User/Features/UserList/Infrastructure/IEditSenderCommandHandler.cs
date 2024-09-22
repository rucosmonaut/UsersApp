namespace Users.WebApp.Applications.User.Features.UserList.Infrastructure;

using OneOf;

public interface IEditSenderCommandHandler
{
    Task<
            OneOf<
                EditedResult,
                UserNotFoundResult>>
        HandleAsync(
            string userId,
            string email);

    public class EditedResult;

    public class UserNotFoundResult;
}
