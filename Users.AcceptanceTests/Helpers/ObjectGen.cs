namespace Users.AcceptanceTests.Helpers;

public static class ObjectGen
{
    public static string CreateEmail()
    {
        return $"{Guid.NewGuid().ToString()}@{Guid.NewGuid().ToString()}";
    }
}
