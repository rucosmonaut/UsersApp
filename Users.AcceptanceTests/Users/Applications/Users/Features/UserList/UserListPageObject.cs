namespace RetailRocket.AcceptanceTests.PartnerOffice.V2.Applications.Documentation.Features.BehavioralMailingsDocumentation
{
    using System;
    using OpenQA.Selenium;
    using Users.AcceptanceTests.Users;

    public class UserListPageObject
        : BasePageObject
    {
        public UserListPageObject(
            IWebDriver driver)
            : base(driver)
        {
        }

        public IWebElement EmptyListWrapper => this
            .Driver
            .FindElement(
                By.Id(
                    idToFind: "emptyUserListContainer"));

        public IWebElement UserEmail => this
            .Driver
            .FindElement(
                By.Id(
                    idToFind: "userEmail"));

        public static UserListPageObject NavigateToPageObject(
            IWebDriver driver)
        {
            driver
                .Navigate()
                .GoToUrl(
                    url: $"https://users.app.local/UserList/ViewList");

            return new UserListPageObject(
                driver: driver);
        }
    }
}
