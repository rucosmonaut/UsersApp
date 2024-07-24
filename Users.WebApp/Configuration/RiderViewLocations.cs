using JetBrains.Annotations;

// shared
[assembly: AspMvcViewLocationFormat("/Applications/Shared/Views/{0}.cshtml")]
[assembly: AspMvcPartialViewLocationFormat("/Applications/Shared/Views/{0}.cshtml")]
[assembly: AspMvcPartialViewLocationFormat("/Applications/Shared/Views/Partials/{0}.cshtml")]

// User application
[assembly: AspMvcViewLocationFormat("/Applications/User/Features/{1}/Views/{0}.cshtml")]
[assembly: AspMvcPartialViewLocationFormat("/Applications/User/Features/{1}/Views/Partials/{0}.cshtml")]
[assembly: AspMvcPartialViewLocationFormat("/Applications/User/Shared/ViewPartials/{0}.cshtml")]
