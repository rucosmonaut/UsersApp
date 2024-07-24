namespace Users.UnitTests.Users.Command;

using global::Users.Application.Common.Exceptions;
using global::Users.Application.Users.Commands.UpdateUser;
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
        handler.Handle(
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
    public Task UpdateUserCommandHandler_FailOnWrongId()
    {
        // Arrange
        var handler = new UpdateUserCommandHandler(Context);
        const string UpdatedEmail = "newemail@gmail.com";

        // Act
        // Assert
        Assert.Throws<NotFoundException>(() =>
            handler.Handle(
                id: Guid.NewGuid(),
                email: UpdatedEmail,
                professionList: new List<Profession>()));

        return Task.CompletedTask;
    }
}
