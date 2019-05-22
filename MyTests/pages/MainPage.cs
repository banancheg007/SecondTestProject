using FirstTestProject.page;
using MyTests.utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTests.pages
{
    class MainPage: Actions
    {
        public By CountryLabel = By.ClassName("geolink__reg");
        public By CountryField = By.Id("city__front-input");
        public By LondonDropBox = By.Id("");

        public void OpenStartUrl()
        {
            Navigate(Constants.SITE_URL);
        }

        public void ChangeCity()
        {
            WaitForEnabled(CountryLabel);
            GetWebElement(CountryLabel).Click();
            WaitForEnabled(CountryField);
            GetWebElement(CountryField).Clear();
            Thread.Sleep(5000);
            GetWebElement(CountryField).SendKeys(Constants.London);
            GetWebElement(CountryField).SendKeys(Keys.Enter);
            Thread.Sleep(5000);
        }
    }
}
