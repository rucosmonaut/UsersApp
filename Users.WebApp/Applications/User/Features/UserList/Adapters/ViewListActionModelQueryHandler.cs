namespace Users.WebApp.Applications.User.Features.UserList.Adapters;

using OneOf;
using Users.WebApp.Applications.User.Features.UserList.Actions.ViewList;
using Users.WebApp.Applications.User.Features.UserList.Views;
using Users.WebApp.Applications.User.Features.UserList.Views.Partials;

internal class ViewListActionModelQueryHandler
    : IViewListActionModelQueryHandler
{
    public async Task<OneOf<ListViewModel, EmptyListViewModel>> HandleAsync(
        string createUserActionUrl,
        string editUserActionUrl)
    {
        var userList = new List<UserPartialViewModel>
        {
            new UserPartialViewModel(
                id: "234",
                email: "test@mail.ru",
                professions: "Designer, Programmer"
                ),
            new UserPartialViewModel(
                id: "52",
                email: "test23@mail.ru",
                professions: "Designer, Programmer"),
            new UserPartialViewModel(
                id: "24",
                email: "324@mail.ru",
                professions: "Designer, Programmer"),
            new UserPartialViewModel(
                id: "34",
                email: "543@mail.ru",
                professions: "Designer, Programmer"),
            new UserPartialViewModel(
                id: "543",
                email: "sdf@mail.ru",
                professions: "Designer, Programmer"),
            new UserPartialViewModel(
                id: "432",
                email: "dsaffsd@fds.ru",
                professions: "Designer, Programmer"),
            new UserPartialViewModel(
                id: "423",
                email: "324@mail.ru",
                professions: "Designer, Programmer")
        };

        await Task.Delay(0);

        if (userList.Any())
        {
            return new ListViewModel(
                createUserFormModalPartialViewModel: new CreateUserFormModalPartialViewModel(
                    createUserActionUrl: createUserActionUrl),
                userList: userList);
        }

        return new EmptyListViewModel(
            createUserFormModalPartialViewModel: new CreateUserFormModalPartialViewModel(
                createUserActionUrl: createUserActionUrl));
    }
}
