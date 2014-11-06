using System;
using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;
using AgeReadyNowSS.ServiceModel;
using AgeReadyNowSS.ServiceInterface;

namespace AgeReadyNowSS.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private readonly ServiceStackHost appHost;

        public UnitTests()
        {
            appHost = new BasicAppHost(typeof(AccountService).Assembly)
            {
                ConfigureContainer = container =>
                {
                    //Add your IoC dependencies here
                }
            }
            .Init();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            appHost.Dispose();
        }

        [Test]
        public void TestMethod1()
        {
            var service = appHost.Container.Resolve<AccountService>();

            //var response = (AccountService)service.Any(new Hello { Name = "World" });

            //Assert.That(response.Result, Is.EqualTo("Hello, World!"));
        }
    }
}
