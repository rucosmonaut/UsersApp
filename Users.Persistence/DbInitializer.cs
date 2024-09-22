namespace Users.Persistence;

public static class DbInitializer
{
    public static void Initialize(
        UsersDbContext context)
    {
        context
            .Database
            .EnsureCreated();
    }
}
