namespace Users.UnitTests.Users.Queries;

using global::Users.Application.Notes.Queries.GetUserList;
using global::Users.Persistence;
using global::Users.UnitTests.Common;
using Shouldly;
using Xunit;

[Collection("QueryCollection")]
public class GetUsersListQueryHandlerTests
{
    private readonly UsersDbContext Context;

    public GetUsersListQueryHandlerTests(QueryTestFixture fixture)
    {
        Context = fixture.Context;
    }

    [Fact]
    public async Task GetUserListQueryHandler_Success()
    {
        // Arrange
        var handler = new GetUserListQueryHandler(Context);

        // Act
        var result = await handler.HandleAsync();

        // Assert
        result.ShouldBeOfType<UserListVm>();
        result.Users.Count.ShouldBe(4);
    }
}
