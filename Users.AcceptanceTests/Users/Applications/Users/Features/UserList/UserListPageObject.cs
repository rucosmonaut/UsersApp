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

        public static UserListPageObject NavigateToPageObject(
            IWebDriver driver)
        {
            driver
                .Navigate()
                .GoToUrl(
                    url: $"https://localhost:5004/UserList/ViewList");

            return new UserListPageObject(
                driver: driver);
        }
    }
}
