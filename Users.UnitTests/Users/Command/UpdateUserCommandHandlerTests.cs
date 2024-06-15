namespace Users.UnitTests.Users.Command;

using global::Users.Application.Common.Exceptions;
using global::Users.Application.Notes.Commands.UpdateUser;
using global::Users.Domain;
using global::Users.UnitTests.Common;
using Microsoft.EntityFrameworkCore;

public class UpdateUserCommandHandlerTests
    : TestCommandBase
{
    [Fact]
    public async Task UpdateUserCommandHandler_Success()
    {
        // Arrange
        var handler = new UpdateUserCommandHandler(Context);
        const string UpdatedEmail = "newemail@gmail.com";

        // Act
        await handler.HandleAsync(
            id: UsersContextFactory.UserIdForUpdate,
            email: UpdatedEmail,
            professionList: new List<Profession>());

        // Assert
        Assert.NotNull(
            @object: await Context
                .Users
                .SingleOrDefaultAsync(
                    predicate: user =>
                        user.Id == UsersContextFactory.UserIdForUpdate
                        && user.Email == UpdatedEmail));
    }

    [Fact]
    public async Task UpdateUserCommandHandler_FailOnWrongId()
    {
        // Arrange
        var handler = new UpdateUserCommandHandler(Context);
        const string UpdatedEmail = "newemail@gmail.com";

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.HandleAsync(
                id: Guid.NewGuid(),
                email: UpdatedEmail,
                professionList: new List<Profession>()));
    }
}
