namespace Users.WebApp.Applications.User.Features.UserList.Views.Partials;

using Users.WebApp.Models;

public sealed class EditUserFormModalPartialViewModel
{
    public EditUserFormModalPartialViewModel(
        string editUserActionUrl,
        List<ListItemViewModel> professionsListItemViewModelList)
    {
        this.EditUserActionUrl = editUserActionUrl;
        this.ProfessionsListItemViewModelList = professionsListItemViewModelList;
    }

    public string EditUserActionUrl { get; set; }

    public List<ListItemViewModel> ProfessionsListItemViewModelList { get; }
}
