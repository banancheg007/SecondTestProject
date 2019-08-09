using Allure.Commons;
using FirstTestProject.main;
using FirstTestProject.page;
using MyTests.pages;
using MyTests.utils;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTests.tests
{
    
    class SmokeTests: BaseTest
    {

        

        private MainPage mainPage;
        private LoginPage loginPage;

        [SetUp]
        public void BeforeTest()
        {
            mainPage = new MainPage();
            loginPage = new LoginPage();
            
        }


        [Ignore("Неактуально")]
        [Test]
        public void VerificationOfContentMoreTab()

        {
          
            mainPage.OpenStartUrl();
            mainPage.ChangeCity(Constants.London);
            var contentMoreTabFirstCity = mainPage.GetContentMoreTab();
            mainPage.ChangeCity(Constants.Paris);
            Assert.AreEqual(contentMoreTabFirstCity, mainPage.GetContentMoreTab());
        }

        [Ignore("Неактуально")]
        [Test]
        public void LoginTest()

        {
            
            mainPage.OpenStartUrl();
            loginPage.Login(Constants.AutotestUserLogin, Constants.AutotestUserPassword);
            Assert.AreEqual(Constants.AutotestUserLogin, loginPage.GetLoggedUserName());
        }

        [Ignore("Неактуально")]
        [Test]
        public void LogoutTest()

        {
            mainPage.OpenStartUrl();
            loginPage.Login(Constants.AutotestUserLogin, Constants.AutotestUserPassword);
            loginPage.Logout();
            Assert.That(loginPage.GetWebElement((loginPage.EnterMailButton)).Displayed, Is.True);
        }

        [Test]
        public void TestWithActions()

        {
            mainPage.OpenStartUrl();
            mainPage.ClickOnElementWithActionsClass(mainPage.MoreTab);
            mainPage.ScrollToElementWithActionsClass(mainPage.TvProgramLabel);
            mainPage.Input(mainPage.SearchField);
        }

        [Test]
        public void TestWithJsExecutor()

        {
            mainPage.OpenStartUrl();
            mainPage.ClickOnElementWithJsExecutor(mainPage.MoreTab);
            mainPage.InputJsExecutor(mainPage.SearchField);
            mainPage.ScrollToElementWithJsExecutor(mainPage.VisitedLabel);
        }

    }
}
