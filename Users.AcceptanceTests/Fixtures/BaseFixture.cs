namespace Users.AcceptanceTests.Fixtures;

    using System;
    using System.ComponentModel;
    using System.Net;
    using System.Reflection;

    public abstract class BaseFixture : IDisposable
    {
        private bool disposed = false;

        protected BaseFixture()
        {
            var applicationName = Assembly.GetExecutingAssembly().GetName().Name;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                                                   SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

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
            GC.SuppressFinalize(this);
        }
    }
