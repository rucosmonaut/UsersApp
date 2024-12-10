namespace Users.AcceptanceTests.Users.Applications.Users.Features.UserList.Tests;

using FluentAssertions;
using global::Users.AcceptanceTests.Fixtures;
using global::Users.AcceptanceTests.Helpers;
using global::Users.AcceptanceTests.Users.Applications.Users.Features.UserList.Commands;
using global::Users.Application.Users.Commands.CreateUser;
using global::Users.Domain;
using Microsoft.Extensions.DependencyInjection;
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
    public void ShouldShowEmptyList()
    {
        TestRunner.Run(
            test: () =>
            {
                this.SetupWithEmptyList();

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
                var randomUserEmail = ObjectGen.RandomEmail();

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
    public void ShouldCreateUser()
    {
        TestRunner.Run(
            test: () =>
            {
                this.SetupWithEmptyList();

                var pageObject = UserListPageObject
                    .NavigateToPageObject(
                        driver: this
                            .fixture
                            .Driver);

                pageObject
                    .CreateUserButton
                    .Click();

                var randomUserEmail = ObjectGen.RandomEmail();

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
                var randomUserEmail = ObjectGen.RandomEmail();

                await this.SetupWithList(randomUserEmail);

                var pageObject = UserListPageObject
                    .NavigateToPageObject(
                        driver: this
                            .fixture
                            .Driver);

                pageObject
                    .EditUserButton
                    .Click();

                var newRandomUserEmail = ObjectGen.RandomEmail();

                pageObject
                    .EditUserEmailInput
                    .Clear();

                pageObject
                    .EditUserEmailInput
                    .SendKeys(newRandomUserEmail);

                pageObject
                    .EditUserFormButton
                    .Click();

                Thread.Sleep(1000);

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
                await this.SetupWithList(ObjectGen.RandomEmail());

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
        this.ClearUserList();

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

    private void SetupWithEmptyList()
    {
        ClearUserList();
    }

    private void ClearUserList()
    {
        var serviceProvider = this
            .fixture
            .ServiceCollection
            .BuildServiceProvider();

        serviceProvider
            .GetRequiredService<IDeleteAllUsersCommandHandler>()
            .Handle();
    }
}
