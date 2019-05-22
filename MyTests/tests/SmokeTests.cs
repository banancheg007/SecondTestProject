using FirstTestProject.main;
using MyTests.pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTests.tests
{
    [TestFixture]
    class SmokeTests
    {
        private MainPage mainPage;

        [SetUp]
        public void BeforeTest()
        {
            mainPage = new MainPage();
        }

        [TearDown]
        public void AfterTest()
        {
            Driver.Destroy();
        }

        [Test]
        public void VerificationOfContentMoreTab()

        {
            mainPage.OpenStartUrl();
            mainPage.ChangeCity();
        }
    }
}
