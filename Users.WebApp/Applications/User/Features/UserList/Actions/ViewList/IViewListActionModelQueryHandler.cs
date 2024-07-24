namespace Users.WebApp.Applications.User.Features.UserList.Actions.ViewList;

using OneOf;
using Users.WebApp.Applications.User.Features.UserList.Views;

public interface IViewListActionModelQueryHandler
{
    Task<
            OneOf<
                ListViewModel,
                EmptyListViewModel>>
        HandleAsync(
            string createUserActionUrl,
            string editUserActionUrl,
            string deleteUserActionUrl);
}
