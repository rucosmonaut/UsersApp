namespace Users.AcceptanceTests.Fixtures;

using OpenQA.Selenium.Chrome;

public class SeleniumFixture
{
    private Timer liveTimer;
    private bool disposed = false;

    public SeleniumFixture()
    {
        this.Driver = this.CreateDriver();
    }

    public ChromeDriver Driver { get; set; }

    protected void Dispose(bool disposing)
    {
        if (this.disposed)
        {
            return;
        }

        if (disposing)
        {
            this.Driver.Quit();
            this.Driver.Dispose();
        }

        this.disposed = true;
    }

    private ChromeDriver CreateDriver()
    {
        var webDriver = DriverFactory.Build();

        webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

        const int AcceptanceTestsTimeLimitInMinutes = 50;

        this.liveTimer = new Timer(
            state =>
            {
                webDriver.Dispose();

                throw new TimeoutException(
                    $"SeleniumFixture: Acceptance test selenium driver was disposed by timeout {AcceptanceTestsTimeLimitInMinutes} minutes.");
            },
            null,
            (uint)TimeSpan.FromMinutes(AcceptanceTestsTimeLimitInMinutes).TotalMilliseconds,
            -1);

        return webDriver;
    }
}
