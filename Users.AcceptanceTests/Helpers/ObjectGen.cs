namespace Users.AcceptanceTests.Helpers;

public static class ObjectGen
{
    public static string RandomEmail()
    {
        return $"{Guid.NewGuid().ToString()}@{Guid.NewGuid().ToString()}";
    }
}
