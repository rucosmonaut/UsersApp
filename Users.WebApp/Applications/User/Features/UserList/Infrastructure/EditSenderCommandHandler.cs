namespace Users.WebApp.Applications.User.Features.UserList.Infrastructure;

using OneOf;

internal class EditSenderCommandHandler
    : IEditSenderCommandHandler
{
    public Task<
            OneOf<
                IEditSenderCommandHandler.EditedResult,
                IEditSenderCommandHandler.UserNotFoundResult>>
        HandleAsync(
            string userId,
            string email)
    {
        throw new NotImplementedException();
    }
}
