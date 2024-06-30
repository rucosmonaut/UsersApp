namespace Users.WebApp.Configuration;

using Microsoft.AspNetCore.Mvc.Razor;

public static class MvcBuilderExtensions
{
    public static IMvcBuilder AddApplicationFeatureFolders(
        this IMvcBuilder builder)
    {
        builder.AddRazorOptions(
            setupAction: options =>
            {
                options
                    .ViewLocationFormats
                    .Clear();

                options.AddSharedLocations();
                options.AddUserApplicationLocations();
            });
        return builder;
    }

    private static void AddSharedLocations(
        this RazorViewEngineOptions options)
    {
        options.ViewLocationFormats.Add("/Views/{0}.cshtml");
        options.ViewLocationFormats.Add("/Views/Partials/{0}.cshtml");
        options.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
        options.ViewLocationFormats.Add("/Views/Shared/Partials/{0}.cshtml");
        options.ViewLocationFormats.Add("/Applications/Shared/Views/{0}.cshtml");
        options.ViewLocationFormats.Add("/Applications/Shared/Views/Partials/{0}.cshtml");
    }

    private static void AddUserApplicationLocations(
        this RazorViewEngineOptions options)
    {
        options.ViewLocationFormats.Add("/Applications/User/Features/{1}/Views/{0}.cshtml");
        options.ViewLocationFormats.Add("/Applications/User/Features/{1}/Views/Partials/{0}.cshtml");
    }
}
