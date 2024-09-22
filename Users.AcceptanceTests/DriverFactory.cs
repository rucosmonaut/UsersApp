namespace Users.AcceptanceTests;

using System;
using System.Drawing;
using OpenQA.Selenium.Chrome;

public static class DriverFactory
{
    public static ChromeDriver Build()
    {
        var chromeOptions = new ChromeOptions();

        chromeOptions.AddArgument("--ignore-certificate-errors");
        chromeOptions.AddArgument("--allow-insecure-localhost");

        var chromeLocation = Environment.GetEnvironmentVariable("ACCEPTANCE_TESTS_CHROME_LOCATION");

        if (!string.IsNullOrEmpty(chromeLocation))
        {
            chromeOptions.BinaryLocation = chromeLocation;
        }

        var webDriver = new ChromeDriver(chromeOptions);

        webDriver.Manage().Window.Size = new Size(
            width: 1200,
            height: 800);

        return webDriver;
    }
}
