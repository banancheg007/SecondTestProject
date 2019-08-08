using FirstTestProject.page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTests.pages
{
    class LoginPage: BasePage
    {
        public By LoginField = By.Id("passp-field-login");
        public By PasswordField = By.Id("passp-field-passwd");
        public By EnterButton= By.XPath("//div[@class='passp-button passp-sign-in-button']//descendant::button[1]");
        public By EnterMailButton = By.XPath("//div[@class='desk-notif-card__card']//descendant::a[3]");
        public By UserNameLabel = By.XPath("//div[@class='mail-User-Name']");
        public By ExitButton = By.LinkText("Выйти из сервисов Яндекса");
        public By InvalidPasswordLabel = By.ClassName("passp-form-field__error");



        public void Login(string login, string password)
        {
            WaitForDisplayed(EnterMailButton);
            GetWebElement(EnterMailButton).Click();
            WaitForDisplayed(LoginField);
            GetWebElement(LoginField).SendKeys(login);
            WaitForDisplayed(EnterButton);
            GetWebElement(EnterButton).Click();
            WaitForDisplayed(PasswordField);
            GetWebElement(PasswordField).SendKeys(password);
            WaitForDisplayed(EnterButton);
            GetWebElement(EnterButton).Click();
        }

        public string GetLoggedUserName()
        {
            WaitForDisplayed(UserNameLabel);
            return GetWebElement(UserNameLabel).Text;
        }

        public void Logout()
        {
            WaitForDisplayed(UserNameLabel);
            GetWebElement(UserNameLabel).Click();
            WaitForDisplayed(ExitButton);
            GetWebElement(ExitButton).Click();
            WaitForDisplayed(EnterMailButton);
        }

        
    }
}
