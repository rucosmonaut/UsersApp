namespace Users.UnitTests.Common;

using global::Users.Persistence;

public class QueryTestFixture
    : IDisposable
{
    public UsersDbContext Context;

    public QueryTestFixture()
    {
        Context = UsersContextFactory.Create();
    }

    public void Dispose()
    {
        UsersContextFactory.Destroy(Context);
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
