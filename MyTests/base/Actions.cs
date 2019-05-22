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
        protected static readonly IWebDriver driver = Driver.Instance();

        protected void Navigate(String url)
        {
            driver.Navigate().GoToUrl(url);
        }

        protected IWebElement GetWebElement(By locator)
        {
            return driver.FindElement(locator);
        }

        public void WaitForDisplayed(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until((driver) => GetWebElement(locator).Displayed == true);
        }

        public void WaitForEnabled(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => GetWebElement(locator).Enabled == true);
        }
    }

}
