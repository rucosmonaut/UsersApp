namespace Users.AcceptanceTests.Users.Applications.Users.Features.UserList.Tests;

using FluentAssertions;
using global::Users.AcceptanceTests.Fixtures;
using global::Users.AcceptanceTests.Helpers;
using global::Users.Application.Users.Commands.CreateUser;
using global::Users.Application.Users.Commands.DeleteUser;
using global::Users.Application.Users.Queries.GetUserList;
using global::Users.Domain;
using Microsoft.Extensions.DependencyInjection;
using RetailRocket.AcceptanceTests.PartnerOffice.V2.Applications.Documentation.Features.BehavioralMailingsDocumentation;
using Xunit;

[Collection(name: SeleniumFixtureCollection.Definition)]
public class DataPresentationTests
{
    private readonly SeleniumFixture fixture;

    public DataPresentationTests(
        SeleniumFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task ShouldShowEmptyList()
    {
        await TestRunner.RunAsync(
            test: async () =>
            {
                await this.SetupWithEmptyList();

                var pageObject = UserListPageObject
                    .NavigateToPageObject(
                        driver: this
                            .fixture
                            .Driver);

                pageObject
                    .EmptyListWrapper
                    .Displayed
                    .Should()
                    .BeTrue();
            },
            seleniumDriver: this
                .fixture
                .Driver);
    }

    [Fact]
    public async Task ShouldShowList()
    {
        await TestRunner.RunAsync(
            test: async () =>
            {
                var randomUserEmail = ObjectGen.CreateEmail();

                await this.SetupWithList(randomUserEmail);

                var pageObject = UserListPageObject
                    .NavigateToPageObject(
                        driver: this
                            .fixture
                            .Driver);

                pageObject
                    .UserEmailLabel
                    .Text
                    .Should()
                    .BeEquivalentTo(randomUserEmail);
            },
            seleniumDriver: this
                .fixture
                .Driver);
    }

    [Fact]
    public async Task ShouldCreateUser()
    {
        await TestRunner.RunAsync(
            test: async () =>
            {
                await this.SetupWithEmptyList();

                var pageObject = UserListPageObject
                    .NavigateToPageObject(
                        driver: this
                            .fixture
                            .Driver);

                pageObject
                    .CreateUserButton
                    .Click();

                var randomUserEmail = ObjectGen.CreateEmail();

                pageObject
                    .CreateUserEmailInput
                    .SendKeys(randomUserEmail);

                pageObject
                    .CreateUserFormButton
                    .Click();

                pageObject
                    .UserEmailLabel
                    .Text
                    .Should()
                    .BeEquivalentTo(randomUserEmail);

            },
            seleniumDriver: this
                .fixture
                .Driver);
    }

    [Fact]
    public async Task ShouldEditUser()
    {
        await TestRunner.RunAsync(
            test: async () =>
            {
                var randomUserEmail = ObjectGen.CreateEmail();

                await this.SetupWithList(randomUserEmail);

                var pageObject = UserListPageObject
                    .NavigateToPageObject(
                        driver: this
                            .fixture
                            .Driver);

                pageObject
                    .EditUserButton
                    .Click();

                var newRandomUserEmail = ObjectGen.CreateEmail();

                pageObject
                    .EditUserEmailInput
                    .Clear();

                pageObject
                    .EditUserEmailInput
                    .SendKeys(newRandomUserEmail);

                pageObject
                    .EditUserFormButton
                    .Click();

                pageObject
                    .UserEmailLabel
                    .Text
                    .Should()
                    .BeEquivalentTo(newRandomUserEmail);

            },
            seleniumDriver: this
                .fixture
                .Driver);
    }

    [Fact]
    public async Task ShouldDeleteUser()
    {
        await TestRunner.RunAsync(
            test: async () =>
            {
                await this.SetupWithList(ObjectGen.CreateEmail());

                var pageObject = UserListPageObject
                    .NavigateToPageObject(
                        driver: this
                            .fixture
                            .Driver);

                pageObject
                    .DeleteUserButton
                    .Click();

                pageObject
                    .DeleteUserFormButton
                    .Click();

                pageObject
                    .EmptyListWrapper
                    .Displayed
                    .Should()
                    .BeTrue();
            },
            seleniumDriver: this
                .fixture
                .Driver);
    }

    private async Task SetupWithList(string userEmail)
    {
        await this.ClearUserList();

        var serviceProvider = this
            .fixture
            .ServiceCollection
            .BuildServiceProvider();

        await serviceProvider
            .GetRequiredService<ICreateUserCommandHandler>()
            .HandleAsync(
                email: userEmail,
                professionList: new List<Profession>
                {
                    Profession.Analyst,
                    Profession.Designer
                });
    }

    private async Task SetupWithEmptyList()
    {
        await this.ClearUserList();
    }

    private async Task ClearUserList()
    {
        var serviceProvider = this
            .fixture
            .ServiceCollection
            .BuildServiceProvider();

        var userListVm = await serviceProvider
            .GetRequiredService<IGetUserListQueryHandler>()
            .HandleAsync();

        var deleteUserCommandHandler = serviceProvider.GetRequiredService<IDeleteUserCommandHandler>();

        foreach (var user in userListVm.Users)
        {
            await deleteUserCommandHandler.HandleAsync(user.Id);
        }
    }
}
