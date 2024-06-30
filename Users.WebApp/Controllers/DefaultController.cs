namespace Users.WebApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using Users.WebApp.Applications.User.Features.UserList;

[Route(template: "/")]
public class DefaultController
    : PartnerControllerBase
{
    public IActionResult Index()
    {
        return this.RedirectToAction(
            actionName: nameof(UserListController.ViewList),
            controllerName: "UserList");
    }
}
