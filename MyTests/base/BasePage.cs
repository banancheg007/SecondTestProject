 using FirstTestProject.main;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTestProject.page
{
    class BasePage
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

        public void UITest(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                var screenshot = driver.TakeScreenshot();
                Random rnd = new Random();
                var filePath = @"C:\allure-2.7.0\screen"+rnd.Next(1,99)+".jpeg";

                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Jpeg);

                // This would be a good place to log the exception message and
                // save together with the screenshot

                throw;
            }
        }
    }

}
