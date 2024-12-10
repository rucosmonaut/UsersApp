namespace Users.AcceptanceTests.Users.Applications.Users.Features.UserList
{
    using OpenQA.Selenium;

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

        public IWebElement UserEmailLabel => this
            .Driver
            .FindElement(
                By.Id(
                    idToFind: "userEmail"));

        public IWebElement CreateUserButton => this
            .Driver
            .FindElement(
                By.Id(
                    idToFind: "createUserButton"));

        public IWebElement CreateUserEmailInput => this
            .Driver
            .FindElement(
                By.Id("createUserEmailInput"));

        public IWebElement EditUserEmailInput => this
            .Driver
            .FindElement(
                By.Id("editUserEmailInput"));

        public IWebElement EditUserFormButton => this
            .Driver
            .FindElement(
                By.Id("editUserFormButton"));

        public IWebElement CreateUserFormButton => this
            .Driver
            .FindElement(
                By.Id("createUserFormButton"));

        public IWebElement EditUserButton => this
            .Driver
            .FindElement(
                By.Id("editUserButton"));

        public IWebElement DeleteUserButton => this
            .Driver
            .FindElement(
                By.Id("deleteUserButton"));

        public IWebElement DeleteUserFormButton => this
            .Driver
            .FindElement(
                By.Id("deleteUserFormButton"));

        public static UserListPageObject NavigateToPageObject(
            IWebDriver driver)
        {
            driver
                .Navigate()
                .GoToUrl(
                    url: $"{BaseUrl}UserList/ViewList");

            return new UserListPageObject(
                driver: driver);
        }
    }
}
