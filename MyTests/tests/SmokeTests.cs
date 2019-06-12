using Allure.Commons;
using FirstTestProject.main;
using FirstTestProject.page;
using MyTests.pages;
using MyTests.utils;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTests.tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureDisplayIgnored]
 
    class SmokeTests
    {

        

        private MainPage mainPage;
        private LoginPage loginPage;

        [SetUp]
        public void BeforeTest()
        {
            mainPage = new MainPage();
            loginPage = new LoginPage();
            
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
            mainPage.ChangeCity(Constants.London);
            var contentMoreTabFirstCity = mainPage.GetContentMoreTab();
            mainPage.ChangeCity(Constants.Paris);
            Assert.AreEqual(contentMoreTabFirstCity, mainPage.GetContentMoreTab());
        }

        [Test]
        public void LoginTest()

        {
            mainPage.UITest(() =>
            {
                mainPage.OpenStartUrl();
            loginPage.Login(Constants.AutotestUserLogin, Constants.AutotestUserPassword);
            Assert.AreEqual(Constants.AutotestUserLogin, loginPage.GetLoggedUserName());
            });
        }

        [Test]
        public void LogoutTest()

        {
            mainPage.OpenStartUrl();
            loginPage.Login(Constants.AutotestUserLogin, Constants.AutotestUserPassword);
            loginPage.Logout();
            Assert.That(loginPage.GetWebElement((loginPage.EnterMailButton)).Displayed, Is.True);
        }

        /* [Test]
        public void InvalidPassword()

        {
            mainPage.OpenStartUrl();
            loginPage.Login(Constants.AutotestUserLogin, Constants.InvalidAutotestUserPassword);
            Thread.Sleep(5000);
            Assert.That(Constants.InvalidPasswordError, Is.EqualTo(loginPage.GetWebElement(loginPage.InvalidPasswordLabel)));
        }

        [Test]
        public void NavigationTest()

        {
            mainPage.OpenStartUrl();
        }*/

    }
}
