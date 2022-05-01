using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using TestItTests.Common;

namespace TestItTests.Drivers
{
    public class DriverFactory
    {
        MyConfig.DriverSettings Driver => new Config().Configure.Driver;
        string Browser => Driver.Browser;
        int Time => Driver.WaitSeconds;

        ChromeOptions Options()
        {
            var opt = new ChromeOptions();
            opt.AddArgument("--ignore-certificate-errors");
            opt.PageLoadStrategy = PageLoadStrategy.Eager;
            return opt;
        }

        public IWebDriver Build()
        {
            IWebDriver result;
            result = Browser switch {
                //"chrome" => new ChromeDriver(Environment.CurrentDirectory, Options()),
                "chrome" => new ChromeDriver(Environment.CurrentDirectory),
                "firefox" => new FirefoxDriver(Environment.CurrentDirectory),
                _ => throw new NotSupportedException($"what a browser '{Browser}'?")
            };
            //result.Manage().Window.Maximize();
            return result;
        }

        public WebDriverWait GetWait(IWebDriver driver)
        {
            WebDriverWait wait;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Time)) {
                PollingInterval = TimeSpan.FromMilliseconds(200)
            };
            wait.IgnoreExceptionTypes(
                typeof(NoSuchElementException),
                typeof(ElementNotVisibleException),
                typeof(StaleElementReferenceException));
            return wait;
        }
    }
    
}
