namespace Users.UnitTests.Users.Command;

using global::Users.Application.Notes.Commands.CreateUser;
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
        var handler = new CreateUserCommandHandler(Context);
        const string UserEmail = "test@gmail.com";
        var userProfessionList = new List<Profession>
        {
            Profession.Analyst,
            Profession.Designer
        };

        // Act
        var noteId = await handler.HandleAsync(
            email: UserEmail,
            professionList: userProfessionList);

        // Assert
        Assert.NotNull(
            await Context.Users.SingleOrDefaultAsync(user =>
                user.Id == noteId
                && user.Email == UserEmail
                && user.ProfessionList == userProfessionList));
    }
}
