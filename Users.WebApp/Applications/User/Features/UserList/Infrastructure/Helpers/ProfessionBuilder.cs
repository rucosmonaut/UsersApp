namespace Users.WebApp.Applications.User.Features.UserList.Infrastructure.Helpers;

using Users.Domain;

public static class ProfessionBuilder
{
    public static List<Profession> BuildProfessionList()
    {
        var professionList = new List<Profession>
        {
            Profession.Analyst,
            Profession.Designer
        };

        return professionList;
    }
}
