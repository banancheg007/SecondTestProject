using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstTestProject.main
{
    public class Driver
    {
        public static IWebDriver driver;
       
        public static IWebDriver CurrentDriver

        {
            get { return Driver.GetInstance(); }
        }

        public static EventFiringWebDriver GetInstance()
        {
            

                if (driver == null)
                {
                    ChromeOptions options = new ChromeOptions();
                    var proxy = new Proxy
                    {
                        Kind = ProxyKind.Manual,
                        IsAutoDetect = false,

                        SslProxy = "91.208.39.70:8080"
                    };
                    options.Proxy = proxy;
                    options.AddArgument("ignore-certificate-errors");
                    driver = new ChromeDriver(options);
                }
            EventFiringWebDriver eventsDriver = new EventFiringWebDriver(driver);
            eventsDriver.ElementClicked += new EventHandler<WebElementEventArgs>(MyElementClickedHandler);
            return eventsDriver;
            
        }
        static void MyElementClickedHandler(object sender, WebElementEventArgs e)
        {
            Console.WriteLine("KURWA");
        }

        static public void Destroy()
        {
            if (driver != null)
            {

                //Driver.CurrentDriver.Manage().Cookies.DeleteAllCookies();
                driver.Close();
                driver.Quit();
                driver = null;
            }
        }
    }
}
