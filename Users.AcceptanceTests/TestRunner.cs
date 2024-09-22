namespace Users.AcceptanceTests;

using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

public static class TestRunner
{
    public static void Run(
        Action test,
        IWebDriver seleniumDriver,
        [CallerMemberName]string methodName = "")
    {
        try
        {
            test();
        }
        catch
        {
            TakeScreenshot(
                seleniumDriver: seleniumDriver,
                methodName: methodName);
            throw;
        }
    }

    public static async Task RunAsync(
        Func<Task> test,
        IWebDriver seleniumDriver,
        [CallerMemberName]string methodName = "")
    {
        try
        {
            await test().ConfigureAwait(false);
        }
        catch
        {
            TakeScreenshot(
                seleniumDriver: seleniumDriver,
                methodName: methodName);
            throw;
        }
    }

    private static void TakeScreenshot(
        IWebDriver seleniumDriver,
        string methodName)
    {
        seleniumDriver
            .TakeScreenshot()
            .SaveAsFile(
                fileName: string.Concat(
                    arg0: methodName,
                    arg1: ".jpg"));
    }
}
