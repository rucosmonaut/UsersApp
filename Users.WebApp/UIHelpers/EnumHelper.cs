namespace Users.WebApp.UIHelpers;

using Users.WebApp.Models;

public static class EnumHelper
{
    public static List<ListItemViewModel> ToListItemViewModelList<T>()
        where T : struct, Enum
    {
        var names = Enum.GetNames<T>();

        var values = Enum.GetValues<T>()
            .Select(value => value.ToString())
            .ToList();

        var listItemViewModelList = new List<ListItemViewModel>();

        if (names.Length != values.Count)
        {
            throw new OperationCanceledException("length of enum names not equals length of enum values");
        }

        for (var i = 0; i < names.Length; i++)
        {
            listItemViewModelList.Add(
                item: new ListItemViewModel(
                    name: names[i],
                    value: values[i]));
        }

        return listItemViewModelList;
    }
}
