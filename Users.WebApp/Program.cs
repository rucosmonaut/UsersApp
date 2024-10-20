using Users.Persistence;
using Users.WebApp.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder
    .Services
    .AddPersistence(builder.Configuration)
    .AddMemoryCache()
    .ConfigurePartnerOfficeServices()
    .AddControllersWithViews(
        configure: options =>
        {
            options.EnableEndpointRouting = false;
        })
    .AddApplicationFeatureFolders();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<UsersDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exception)
    {
        Console.WriteLine(@"An error occurred while app initialization: {0}", exception);
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles(
    options: new StaticFileOptions
    {
        FileProvider = new ApplicationFeatureContentFileProvider(
            rootFolder: builder
                .Environment
                .ContentRootPath)
    });

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller}/{action}",
        defaults: new { controller = "default", action = "index" }
    );
});

app.Run();
