namespace Users.WebApp.Applications.User.Features.UserList.Views.Partials;

using Users.WebApp.Models;

public sealed class CreateUserFormModalPartialViewModel
{
    public CreateUserFormModalPartialViewModel(
        string createUserActionUrl,
        List<ListItemViewModel> professionsListItemViewModelList)
    {
        this.CreateUserActionUrl = createUserActionUrl;
        this.ProfessionsListItemViewModelList = professionsListItemViewModelList;
    }

    public string CreateUserActionUrl { get; }

    public List<ListItemViewModel> ProfessionsListItemViewModelList { get; }
}
