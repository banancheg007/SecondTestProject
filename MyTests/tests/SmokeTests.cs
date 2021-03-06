﻿using Allure.Commons;
using FirstTestProject.main;
using FirstTestProject.page;
using MyTests.pages;
using MyTests.utils;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
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

    }
}
