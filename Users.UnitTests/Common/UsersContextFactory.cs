namespace Users.UnitTests.Common;

using global::Users.Domain;
using global::Users.Persistence;
using Microsoft.EntityFrameworkCore;

internal class UsersContextFactory
{
    internal static Guid UserIdForDelete = Guid.NewGuid();

    internal static Guid UserIdForUpdate = Guid.NewGuid();

    public static UsersDbContext Create()
    {
        var options = new DbContextOptionsBuilder<UsersDbContext>()
            .UseInMemoryDatabase(
                databaseName: Guid
                    .NewGuid()
                    .ToString())
            .Options;

        var context = new UsersDbContext(options);

        context
            .Database
            .EnsureCreated();

        context.Users.AddRange(
            entities: new[]
            {
                new User
                {
                    Id = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                    Email = "email1@gmail.com",
                    ProfessionList = new List<Profession>
                    {
                        Profession.Analyst,
                        Profession.Designer
                    },
                    CreationDate = DateTime.Today,
                    EditDate = null,
                    DeletedDate = null
                },
                new User
                {
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                    Email = "email2@gmail.com",
                    ProfessionList = new List<Profession>
                    {
                        Profession.Analyst,
                        Profession.Designer
                    },
                    CreationDate = DateTime.Today,
                    EditDate = null,
                    DeletedDate = null
                },
                new User
                {
                    Id = UserIdForDelete,
                    Email = "email3@gmail.com",
                    ProfessionList = new List<Profession>
                    {
                        Profession.Analyst,
                        Profession.Designer
                    },
                    CreationDate = DateTime.Today,
                    EditDate = null,
                    DeletedDate = null
                },
                new User
                {
                    Id = UserIdForUpdate,
                    Email = "email4@gmail.com",
                    ProfessionList = new List<Profession>
                    {
                        Profession.Analyst,
                        Profession.Designer
                    },
                    CreationDate = DateTime.Today,
                    EditDate = null,
                    DeletedDate = null
                }
            });
        context.SaveChanges();
        return context;
    }

    public static void Destroy(
        UsersDbContext context)
    {
        context
            .Database
            .EnsureDeleted();
        context.Dispose();
    }
}
