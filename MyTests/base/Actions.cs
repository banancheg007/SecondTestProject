 using FirstTestProject.main;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTestProject.page
{
    class Actions
    {
         public static IWebDriver driver = Driver.CurrentDriver;

        protected void Navigate(String url)
        {
            Driver.CurrentDriver.Navigate().GoToUrl(url);
        }

        public IWebElement GetWebElement(By locator)
        {
            return Driver.CurrentDriver.FindElement(locator);
        }

        protected IList<IWebElement> GetWebElements(By locator)
        {
            return Driver.CurrentDriver.FindElements(locator);
        }

        public void WaitForDisplayed(By locator)
        {
            WebDriverWait wait = new WebDriverWait(Driver.CurrentDriver, TimeSpan.FromSeconds(20));
            wait.Until((driver) => GetWebElement(locator).Displayed == true);
        }

        public void WaitForEnabled(By locator)
        {
            WebDriverWait wait = new WebDriverWait(Driver.CurrentDriver, TimeSpan.FromSeconds(20));
            wait.Until(driver => GetWebElement(locator).Enabled == true);
        }
    }

}
