namespace Users.WebApp.Applications.User.Features.UserList.Infrastructure;

using OneOf;

public interface ICreateUserCommandHandler
{
    Task<
            OneOf<
                AddedResult,
                AlreadyExistsResult>>
        HandleAsync(
            string email);

    public class AddedResult
    {
        public AddedResult(
            Guid userId)
        {
            this.UserId = userId;
        }

        public Guid UserId { get; }
    }

    public abstract class AlreadyExistsResult;
}
