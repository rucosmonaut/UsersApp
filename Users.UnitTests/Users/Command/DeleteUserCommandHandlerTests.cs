namespace Users.UnitTests.Users.Command;

using global::Users.Application.Common.Exceptions;
using global::Users.Application.Users.Commands.DeleteUser;
using global::Users.Domain;
using global::Users.UnitTests.Common;

public class DeleteUserCommandHandlerTests
    : TestCommandBase
{
            [Fact]
        public async Task DeleteUserCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteUserCommandHandler(Context);

            // Act
            await handler.HandleAsync(UsersContextFactory.UserIdForDelete);

            // Assert
            Assert.Null(
                @object: Context
                    .Users
                    .SingleOrDefault(user =>
                        user.Id == UsersContextFactory.UserIdForDelete));
        }

        [Fact]
        public async Task DeleteUserCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteUserCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(
                testCode: async () => await handler.HandleAsync(
                    id: Guid.NewGuid()));
        }
}
