namespace Users.UnitTests.Users.Command;

using global::Users.Application.Users.Commands.CreateUser;
using global::Users.Domain;
using global::Users.UnitTests.Common;
using Microsoft.EntityFrameworkCore;

public class CreateUserCommandHandlerTests
    : TestCommandBase
{
    [Fact]
    public async Task CreateUserCommandHandler_Success()
    {
        // Arrange
        var handler = new CreateUserCommandHandler(this.Context);
        const string UserEmail = "test@gmail.com";
        var userProfessionList = new List<Profession>
        {
            Profession.Analyst,
            Profession.Designer
        };

        // Act
        var userId = await handler.HandleAsync(
            email: UserEmail,
            professionList: userProfessionList);

        // Assert
        Assert.NotNull(
            await this
                .Context
                .Users
                .SingleOrDefaultAsync(user =>
                    user.Id == userId
                    && user.Email == UserEmail
                    && user.ProfessionList == userProfessionList));
    }
}
