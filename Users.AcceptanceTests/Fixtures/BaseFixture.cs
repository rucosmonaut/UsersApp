namespace Users.AcceptanceTests.Fixtures;

    using System;
    using System.ComponentModel;
    using global::Users.AcceptanceTests.Users.Applications.Users.Features.UserList.CommandHandlers;
    using global::Users.AcceptanceTests.Users.Applications.Users.Features.UserList.Commands;
    using global::Users.Application.Interfaces;
    using global::Users.Application.Users.Commands.CreateUser;
    using global::Users.Application.Users.Commands.DeleteUser;
    using global::Users.Application.Users.Commands.UpdateUser;
    using global::Users.Application.Users.Queries.GetUserList;
    using global::Users.Persistence;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using MongoDB.Driver;
    using OpenQA.Selenium.DevTools.V125.Debugger;

    public abstract class BaseFixture
        : IDisposable
    {
        private bool disposed = false;

        public Scope Scope { get; }

        public ServiceCollection ServiceCollection { get; }

        protected BaseFixture(
            Scope scope)
        {
            this.Scope = scope;

            this.Container = new Container();

            this.ServiceCollection = new ServiceCollection();

            var optionBuilder = new DbContextOptionsBuilder<UsersDbContext>();

            var сonnectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");

            var mongoDbClient = new MongoClient(
                new MongoClientSettings
                {
                    Server = new MongoServerAddress(сonnectionString)
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

            this
                .ServiceCollection
                .AddSingleton<IDeleteAllUsersCommandHandler>(
                    new DeleteAllUsersCommandHandler(dbContext));

            this
                .ServiceCollection
                .AddSingleton<IDeleteAllUsersCommandHandler>(
                    new DeleteAllUsersCommandHandler(dbContext));
        }

        ~BaseFixture()
        {
            this.Dispose();
        }

        public Container Container { get; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(
            bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            this.disposed = true;
        }
    }
