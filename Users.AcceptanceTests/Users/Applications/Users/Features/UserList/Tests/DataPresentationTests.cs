namespace Users.AcceptanceTests.Users.Applications.Users.Features.UserList.Tests;

using FluentAssertions;
using global::Users.AcceptanceTests.Fixtures;
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
    public void ShouldShowEmptyList()
    {
        TestRunner.Run(
            test: () =>
            {
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
}
