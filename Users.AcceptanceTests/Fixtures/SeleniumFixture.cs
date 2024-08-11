namespace Users.AcceptanceTests.Fixtures;

using global::Users.Application.Interfaces;
using global::Users.Application.Users.Commands.CreateUser;
using global::Users.Application.Users.Commands.DeleteUser;
using global::Users.Application.Users.Commands.UpdateUser;
using global::Users.Application.Users.Queries.GetUserList;
using global::Users.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OpenQA.Selenium.Chrome;

public class SeleniumFixture
{
    private bool disposed = false;

    public ServiceCollection ServiceCollection { get; }

    public SeleniumFixture()
    {
        this.Driver = CreateDriver();

        this.ServiceCollection = new ServiceCollection();

        var optionBuilder = new DbContextOptionsBuilder<UsersDbContext>();

        const string ConnectionString = "localhost";

        var mongoDbClient = new MongoClient(
            new MongoClientSettings
            {
                Server = new MongoServerAddress(ConnectionString)
            });

        optionBuilder.UseMongoDB(mongoDbClient, "Users");

        var dbContext = new UsersDbContext(optionBuilder.Options);

        this.
            ServiceCollection
            .AddScoped<IUsersDbContext>(
                implementationFactory: provider => dbContext);

        this
            .ServiceCollection
            .AddSingleton<ICreateUserCommandHandler>(
                new CreateUserCommandHandler(dbContext));

        this
            .ServiceCollection
            .AddSingleton<IDeleteUserCommandHandler>(
                new DeleteUserCommandHandler(dbContext));

        this
            .ServiceCollection
            .AddSingleton<IUpdateUserCommandHandler>(
                new UpdateUserCommandHandler(dbContext));

        this
            .ServiceCollection
            .AddSingleton<IGetUserListQueryHandler>(
                new GetUserListQueryHandler(dbContext));
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
