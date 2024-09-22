namespace Users.AcceptanceTests.Fixtures;

using Xunit;

[CollectionDefinition(Definition)]
public class SeleniumFixtureCollection : ICollectionFixture<SeleniumFixture>
{
    public const string Definition = "Selenium fixture collection";
}
