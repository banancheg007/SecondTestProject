using FirstTestProject.main;
using FirstTestProject.page;
using MyTests.utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTests.pages
{
    class MainPage: BasePage
    {
        public By CountryLabel = By.ClassName("geolink__reg");
        public By CountryField = By.Id("city__front-input");
        public By MoreTabItems = By.ClassName("home-tabs__more-item");
        public By MoreTab = By.XPath("//a[text()='ещё']");
        public By NavigationTabItems = By.XPath("//descendant::div[@class='home-tabs stream-control dropdown2 dropdown2_switcher_elem i-bem home-tabs_js_inited']");

        public void OpenStartUrl()
        {
            Navigate(Constants.SITE_URL);
        }

        public void ChangeCity(string city)
        {
            WaitForEnabled(CountryLabel);
            GetWebElement(CountryLabel).Click();
            WaitForEnabled(CountryField);
            GetWebElement(CountryField).Clear();
            GetWebElement(CountryField).SendKeys(city);
            WaitForEnabled(By.XPath($"//*[text()='{city}']"));
            GetWebElement(By.XPath($"//*[text()='{city}']")).Click();
        }

        public IList<string> GetContentMoreTab()
        {
            //Thread.Sleep(10000);
            WaitForDisplayed(MoreTab);
            GetWebElement(MoreTab).Click();
            var contentMoreTab =  GetWebElements(MoreTabItems);
            IList<string> contentMoreTabStrings = new List<string>();
            Console.WriteLine("\nCurrent List items\n");
            foreach (IWebElement webElement in contentMoreTab)
            {
                contentMoreTabStrings.Add(webElement.Text);
                Console.WriteLine(webElement.Text);
            }
            return contentMoreTabStrings;
        }



         public void ClickOnMoreTabWithActionsClass()
        {
            
            WaitForDisplayed(MoreTab);
            Actions actions = new Actions(Driver.CurrentDriver);
            actions.Click(GetWebElement(MoreTab)).Build().Perform();
        }


    }
}
