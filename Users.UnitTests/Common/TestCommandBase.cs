namespace Users.UnitTests.Common;

using global::Users.Persistence;

public abstract class TestCommandBase
    : IDisposable
{
    protected readonly UsersDbContext Context;

    public TestCommandBase()
    {
        Context = UsersContextFactory.Create();
    }

    public void Dispose()
    {
        UsersContextFactory.Destroy(this.Context);
    }
}
