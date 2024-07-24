namespace Users.WebApp.Applications.User.Features.UserList.Adapters;

using OneOf;
using Users.Domain;
using Users.WebApp.Applications.User.Features.UserList.Actions.ViewList;
using Users.WebApp.Applications.User.Features.UserList.Infrastructure;
using Users.WebApp.Applications.User.Features.UserList.Views;
using Users.WebApp.Applications.User.Features.UserList.Views.Partials;
using Users.WebApp.UIHelpers;

internal class ViewListActionModelQueryHandler
    : IViewListActionModelQueryHandler
{
    private readonly UserListQueryHandler userListQueryHandler;

    public ViewListActionModelQueryHandler(
        UserListQueryHandler userListQueryHandler)
    {
        this.userListQueryHandler = userListQueryHandler;
    }

    public async Task<OneOf<ListViewModel, EmptyListViewModel>> HandleAsync(
        string createUserActionUrl,
        string editUserActionUrl,
        string deleteUserActionUrl)
    {
        var userList = await userListQueryHandler.HandleAsync();

        if (userList.Any())
        {
            return new ListViewModel(
                createUserFormModalPartialViewModel: new CreateUserFormModalPartialViewModel(
                    createUserActionUrl: createUserActionUrl,
                    professionsListItemViewModelList: EnumHelper.ToListItemViewModelList<Profession>()),
                userPartialViewModelList: userList
                    .Select(
                        selector: user => new UserPartialViewModel(
                            id: user
                                .Id
                                .ToString(),
                            email: user.Email,
                            professions: string.Join(", ", user.ProfessionList.Select(profession => profession.ToString()))))
                    .ToList(),
                editUserFormModalPartialViewModel: new EditUserFormModalPartialViewModel(
                    editUserActionUrl: editUserActionUrl,
                    professionsListItemViewModelList: EnumHelper.ToListItemViewModelList<Profession>()),
                deleteUserFormModalPartialViewModel: new DeleteUserFormModalPartialViewModel(
                    deleteUserActionUrl: deleteUserActionUrl));
        }

        return new EmptyListViewModel(
            createUserFormModalPartialViewModel: new CreateUserFormModalPartialViewModel(
                createUserActionUrl: createUserActionUrl,
                professionsListItemViewModelList: EnumHelper.ToListItemViewModelList<Profession>()));
    }
}
