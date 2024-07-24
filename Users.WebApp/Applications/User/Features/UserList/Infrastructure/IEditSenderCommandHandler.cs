namespace Users.WebApp.Applications.User.Features.UserList.Infrastructure;

using OneOf;

public interface IEditSenderCommandHandler
{
    OneOf<
            EditedResult,
            UserNotFoundResult>
        Handle(
            string userId,
            string email);

    public class EditedResult;

    public class UserNotFoundResult;
}
