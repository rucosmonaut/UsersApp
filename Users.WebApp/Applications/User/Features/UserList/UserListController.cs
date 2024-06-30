namespace Users.WebApp.Applications.User.Features.UserList;

using Microsoft.AspNetCore.Mvc;
using Users.WebApp.Applications.User.Features.UserList.Actions.CreateUser;
using Users.WebApp.Applications.User.Features.UserList.Actions.EditUser;
using Users.WebApp.Applications.User.Features.UserList.Actions.ViewList;
using Users.WebApp.Applications.User.Features.UserList.Infrastructure;
using Users.WebApp.Controllers;

[Route(template: "UserList/[action]")]
public class UserListController
    : PartnerControllerBase
{
    private readonly IViewListActionModelQueryHandler viewListActionModelQueryHandler;

    private readonly ICreateUserCommandHandler createUserCommandHandler;

    public UserListController(
        IViewListActionModelQueryHandler viewListActionModelQueryHandler,
        ICreateUserCommandHandler createUserCommandHandler)
    {
        this.viewListActionModelQueryHandler = viewListActionModelQueryHandler;
        this.createUserCommandHandler = createUserCommandHandler;
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
                            controller: "UserList")!)
                .ConfigureAwait(false))
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
                .HandleAsync(
                    requestModel.Email)
                .ConfigureAwait(false))
            .Match(
                addedResult => this
                    .RedirectToAction(
                        actionName: nameof(ViewList),
                        controllerName: "UserList"),
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
                .createUserCommandHandler
                .HandleAsync(
                    requestModel.Email)
                .ConfigureAwait(false))
            .Match(
                addedResult => this
                    .RedirectToAction(
                        actionName: nameof(ViewList),
                        controllerName: "UserList"),
                alreadyExistsResult => this
                    .RedirectToAction(
                        actionName: nameof(ViewList),
                        controllerName: "UserList"));
    }
}
