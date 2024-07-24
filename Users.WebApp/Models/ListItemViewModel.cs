namespace Users.WebApp.Models;

public class ListItemViewModel
{
    public ListItemViewModel(
        string name,
        string value)
    {
        this.Name = name;
        this.Value = value;
    }

    public string Name { get; }

    public string Value { get; }
}
