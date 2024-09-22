namespace Users.AcceptanceTests.Fixtures;

    using System;
    using System.ComponentModel;
    using OpenQA.Selenium.DevTools.V125.Debugger;

    public abstract class BaseFixture
        : IDisposable
    {
        private bool disposed = false;

        public Scope Scope { get; }

        protected BaseFixture(
            Scope scope)
        {
            this.Scope = scope;
            this.Container = new Container();
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
