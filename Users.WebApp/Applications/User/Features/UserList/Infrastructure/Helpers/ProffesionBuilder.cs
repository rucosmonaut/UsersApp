namespace Users.WebApp.Applications.User.Features.UserList.Infrastructure.Helpers;

using Users.Domain;

public static class ProffesionBuilder
{
    public static List<Profession> BuildProfessionList()
    {
        var professionList = new List<Profession>();

        professionList.Add(Profession.Analyst);
        professionList.Add(Profession.Designer);

        return professionList;
    }
}
