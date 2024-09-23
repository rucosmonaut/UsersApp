namespace Users.AcceptanceTests.Users;

using OpenQA.Selenium;

public class BasePageObject
{
    private readonly IWebDriver driver;

    protected BasePageObject(IWebDriver driver)
    {
        this.driver = driver;
    }

    protected string PageUrl => this.driver.Url;

    protected IWebDriver Driver => this.driver;

    protected static string BaseUrl => Environment.GetEnvironmentVariable("UsersAppBaseUrl")!;
}
