﻿using FirstTestProject.main;
using MyTests.pages;
using MyTests.utils;
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

        [OneTimeTearDown]
        public void Cleanup()
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
            mainPage.OpenStartUrl();
            loginPage.Login(Constants.AutotestUserLogin, Constants.AutotestUserPassword);
            Assert.AreEqual(Constants.AutotestUserLogin, loginPage.GetLoggedUserName());
        }

    }
}
