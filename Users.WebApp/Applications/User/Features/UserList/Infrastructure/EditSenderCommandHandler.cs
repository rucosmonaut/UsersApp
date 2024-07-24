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

    public OneOf<
            IEditSenderCommandHandler.EditedResult,
            IEditSenderCommandHandler.UserNotFoundResult>
        Handle(
            string userId,
            string email)
    {
        updateUserCommandHandler.Handle(
            id: Guid.Parse(userId),
            email: email,
            professionList: ProfessionBuilder.BuildProfessionList());

        return new IEditSenderCommandHandler.EditedResult();
    }
}
