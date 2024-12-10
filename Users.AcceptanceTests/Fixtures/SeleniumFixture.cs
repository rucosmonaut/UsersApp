namespace Users.AcceptanceTests.Fixtures;

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V125.Debugger;

public abstract class SeleniumFixture
    : BaseFixture
{
    private bool disposed = false;

    public readonly ChromeDriver Driver;

    protected SeleniumFixture()
        : base(new Scope())
    {
        this.Driver = CreateDriver();
    }

    protected override void Dispose(bool disposing)
    {
        if (this.disposed)
        {
            return;
        }

        if (disposing)
        {
            this
                .Driver
                .Quit();

            this
                .Driver
                .Dispose();
        }

        this.disposed = true;
    }

    private static ChromeDriver CreateDriver()
    {
        var webDriver = DriverFactory.Build();

        webDriver
            .Manage()
            .Timeouts()
            .ImplicitWait = TimeSpan.FromSeconds(1);

        const int AcceptanceTestsTimeLimitInMinutes = 50;

        new Timer(
            callback: state =>
            {
                webDriver.Dispose();
            },
            state: null,
            dueTime: (uint)TimeSpan.FromMinutes(AcceptanceTestsTimeLimitInMinutes).TotalMilliseconds,
            period: -1);

        return webDriver;
    }
}
