namespace Users.UnitTests.Common;

using global::Users.Persistence;

// ReSharper disable once ClassNeverInstantiated.Global
public class QueryTestFixture
    : IDisposable
{
    public readonly UsersDbContext Context;

    public QueryTestFixture()
    {
        Context = UsersContextFactory.Create();
    }

    public void Dispose()
    {
        UsersContextFactory.Destroy(this.Context);
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture>
    {
    }
}
