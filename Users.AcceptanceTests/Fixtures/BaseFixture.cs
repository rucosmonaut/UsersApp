namespace Users.AcceptanceTests.Fixtures;

    using System;
    using System.ComponentModel;
    using System.Net;
    using System.Reflection;
    using OpenQA.Selenium.DevTools.V125.Debugger;

    public abstract class BaseFixture
        : IDisposable
    {
        private bool disposed = false;

        public Scope Scope { get; }

        protected BaseFixture()
        {
            var applicationName = Assembly.GetExecutingAssembly().GetName().Name;

            this.Container = new Container();
        }

        ~BaseFixture()
        {
            this.Dispose();
        }


        public static string TestSessionId => Environment.MachineName.Replace("-", string.Empty).ToLower() + "1";

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
