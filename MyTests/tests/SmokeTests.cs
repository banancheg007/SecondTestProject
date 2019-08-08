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
            
            mainPage.OpenStartUrl();
            loginPage.Login(Constants.AutotestUserLogin, Constants.AutotestUserPassword);
            Assert.AreEqual(Constants.AutotestUserLogin, loginPage.GetLoggedUserName());
        }

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
            //loginPage.Login(Constants.AutotestUserLogin, Constants.AutotestUserPassword);
            //loginPage.Logout();
            //Assert.That(loginPage.GetWebElement((loginPage.EnterMailButton)).Displayed, Is.True);
            mainPage.ClickOnElementWithActionsClass(mainPage.MoreTab);
            mainPage.ScrollToElementWithActionsClass(mainPage.TvProgramLabel);
            mainPage.Input(mainPage.SearchField);
        }


    }
}
