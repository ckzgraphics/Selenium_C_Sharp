using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;

using System.Linq;
using OpenQA.Selenium.Remote;

namespace Selenium_C_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver driver;
            DesiredCapabilities capability = new DesiredCapabilities();
            IWebElement ele = null;

            capability.SetCapability("project", "Automate Support Project");
            capability.SetCapability("build", "Support Automate");
            capability.SetCapability("name", "Test: Switch To Window C#");

            capability.SetCapability("os", "Windows");
            capability.SetCapability("os_version", "7");

            capability.SetCapability("browserName", "Firefox");
            capability.SetCapability("browserVersion", "60.0");
            capability.SetCapability("browserstack.use_w3c", true);

            //capability.SetCapability("browserstack.selenium_version", "3.5.2");

            capability.SetCapability("browserstack.user", Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME"));
            capability.SetCapability("browserstack.key", Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY"));

            driver = new RemoteWebDriver(
              new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability
            );

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");


            Console.WriteLine(driver.Title);

            ele = driver.FindElement(By.XPath(".//div/a[contains(.,'Click Here')]"));
            ele.Click();
            Thread.Sleep(6000);


            String mainWindow = driver.CurrentWindowHandle;

            List<string> subWindow = driver.WindowHandles.ToList();


            String newWindow = null;

            foreach (String handle in subWindow)

            {
                Console.WriteLine("Windows : " + handle);
                newWindow = handle;
            }

            driver.SwitchTo().Window(newWindow);
            Thread.Sleep(2000);
            Console.WriteLine(driver.Title);

            driver.SwitchTo().Window(mainWindow);
            Thread.Sleep(2000);
            Console.WriteLine(driver.Title);

            driver.Quit();
        } // MAIN END

    } // CLASS END

} // NAMESPACE END