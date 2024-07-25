namespace Users.WebApp.Applications.User.Features.UserList;

using Microsoft.AspNetCore.Mvc;
using Users.WebApp.Applications.User.Features.UserList.Actions.CreateUser;
using Users.WebApp.Applications.User.Features.UserList.Actions.DeleteUser;
using Users.WebApp.Applications.User.Features.UserList.Actions.EditUser;
using Users.WebApp.Applications.User.Features.UserList.Actions.ViewList;
using Users.WebApp.Applications.User.Features.UserList.Infrastructure;
using Users.WebApp.Controllers;
using Users.WebApp.UIHelpers;

[Route(template: "UserList/[action]")]
public class UserListController
    : PartnerControllerBase
{
    private readonly IViewListActionModelQueryHandler viewListActionModelQueryHandler;

    private readonly ICreateUserCommandHandler createUserCommandHandler;

    private readonly IEditSenderCommandHandler editSenderCommandHandler;

    private readonly IDeleteUserCommandHandler deleteUserCommandHandler;

    public UserListController(
        IViewListActionModelQueryHandler viewListActionModelQueryHandler,
        ICreateUserCommandHandler createUserCommandHandler,
        IEditSenderCommandHandler editSenderCommandHandler,
        IDeleteUserCommandHandler deleteUserCommandHandler)
    {
        this.viewListActionModelQueryHandler = viewListActionModelQueryHandler;
        this.createUserCommandHandler = createUserCommandHandler;
        this.editSenderCommandHandler = editSenderCommandHandler;
        this.deleteUserCommandHandler = deleteUserCommandHandler;
    }

    public async Task<IActionResult> ViewList()
    {
        return (await this
                .viewListActionModelQueryHandler
                .HandleAsync(
                    createUserActionUrl: this
                        .Url
                        .Action(
                            action: nameof(this.CreateUser),
                            controller: "UserList")!,
                    editUserActionUrl: this
                        .Url
                        .Action(
                            action: nameof(this.EditUser),
                            controller: "UserList")!,
                    deleteUserActionUrl: this
                        .Url
                        .Action(
                            action: nameof(this.DeleteUser),
                            controller: "UserList")!))
            .Match(
                listViewModel => this.View(
                    viewName: "List",
                    model: listViewModel),
                emptyListViewModel => this.View(
                    viewName: "EmptyList",
                    model: emptyListViewModel));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateUser(
        CreateUserRequestModel requestModel)
    {
        return (await this
                .createUserCommandHandler
                .HandleAsync(requestModel.Email))
            .Match(
                addedResult => this
                    .RedirectToAction(
                        actionName: nameof(ViewList),
                        controllerName: "UserList")
                    .WithAlert(
                        alertClass: AlertClass.Success,
                        message: "Success",
                        httpContext: this.HttpContext),
                alreadyExistsResult => this
                    .RedirectToAction(
                        actionName: nameof(ViewList),
                        controllerName: "UserList"));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditUser(
        EditUserRequestModel requestModel)
    {
        return (await this
            .editSenderCommandHandler
            .HandleAsync(
                userId: requestModel.Id,
                email: requestModel.Email))
            .Match(
                editedResult => this
                    .RedirectToAction(
                        actionName: nameof(ViewList),
                        controllerName: "UserList"),
                notFoundResult => this
                    .RedirectToAction(
                        actionName: nameof(ViewList),
                        controllerName: "UserList"));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteUser(
        DeleteUserRequestModel requestModel)
    {
        return (await this
                .deleteUserCommandHandler
                .HandleAsync(requestModel.Id))
            .Match(
                editedResult => this
                    .RedirectToAction(
                        actionName: nameof(ViewList),
                        controllerName: "UserList"),
                notFoundResult => this
                    .RedirectToAction(
                        actionName: nameof(ViewList),
                        controllerName: "UserList"));
    }
}
