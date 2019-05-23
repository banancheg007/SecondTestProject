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
        public By GreatBritainDropBox = By.XPath("//*[text()='Великобритания']");
        public By MoreTabItems = By.ClassName("home-tabs__more-item");
        public By MoreTab = By.XPath("//div[@class='home-arrow__tabs']//descendant::a[9]");

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
            WaitForEnabled(GreatBritainDropBox);
            GetWebElement(GreatBritainDropBox).Click();
        }

        public IReadOnlyCollection<IWebElement> GetContentMoreTab()
        {
            WaitForDisplayed(MoreTab);
            Thread.Sleep(20000);
            GetWebElement(MoreTab).Click();
            return GetWebElements(MoreTabItems);
        }
    }
}
