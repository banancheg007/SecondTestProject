 using FirstTestProject.main;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        Actions actions = new Actions(Driver.CurrentDriver);
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

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

        public void ClickOnElementWithActionsClass(By locator)
        {

            WaitForDisplayed(locator);
            actions.Click(GetWebElement(locator)).Perform();
        }

        public void ScrollToElementWithActionsClass(By locator)
        {
            WaitForDisplayed(locator);
            actions.MoveToElement(GetWebElement(locator)).Perform();
        }

        public void Input(By locator)
        {
            WaitForDisplayed(locator);
            actions.SendKeys(GetWebElement(locator), "Test text").Perform();
        }



        public void ClickOnElementWithJsExecutor(By locator)
        {
            WaitForDisplayed(locator);
            js.ExecuteScript("arguments[0].click();", GetWebElement(locator));
        }

        public void ScrollToElementWithJsExecutor(By locator)
        {
            WaitForDisplayed(locator);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", GetWebElement(locator));
        }

        public void InputJsExecutor(By locator)
        {
            WaitForDisplayed(locator);
            js.ExecuteScript("arguments[0].setAttribute('value', '" + "test text" + "')", GetWebElement (locator));
        }
    }

}
