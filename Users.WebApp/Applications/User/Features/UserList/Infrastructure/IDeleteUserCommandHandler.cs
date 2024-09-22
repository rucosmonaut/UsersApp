namespace Users.WebApp.Applications.User.Features.UserList.Infrastructure;

using OneOf;

public interface IDeleteUserCommandHandler
{
    Task<
            OneOf<
                DeletedResult,
                NotFoundResult>>
        HandleAsync(
            string userId);

    public class DeletedResult;

    public abstract class NotFoundResult;
}
