namespace Users.WebApp.Applications.User.Features.UserList.Infrastructure;

using OneOf;
using Users.Application.Users.Commands.UpdateUser;
using Users.WebApp.Applications.User.Features.UserList.Infrastructure.Helpers;

internal class EditSenderCommandHandler
    : IEditSenderCommandHandler
{
    private readonly IUpdateUserCommandHandler updateUserCommandHandler;

    public EditSenderCommandHandler(
        IUpdateUserCommandHandler updateUserCommandHandler)
    {
        this.updateUserCommandHandler = updateUserCommandHandler;
    }

    public async Task<
            OneOf<
                IEditSenderCommandHandler.EditedResult,
                IEditSenderCommandHandler.UserNotFoundResult>>
        HandleAsync(
            string userId,
            string email)
    {
        await updateUserCommandHandler.HandleAsync(
            id: Guid.Parse(userId),
            email: email,
            professionList: ProfessionBuilder.BuildProfessionList());

        return new IEditSenderCommandHandler.EditedResult();
    }
}
