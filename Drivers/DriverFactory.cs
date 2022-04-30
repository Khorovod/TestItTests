using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestItTests.Common;

namespace TestItTests.Drivers
{
    public class DriverFactory
    {
        MyConfig.DriverSettings Driver => new Config().Configure.Driver;
        string Browser => Driver.Browser;
        int Time => Driver.WaitSeconds;

        public IWebDriver Build()
        {
            IWebDriver result;

            result = Browser switch {
                "chrome" => new ChromeDriver(Environment.CurrentDirectory, new ChromeOptions() { }),
                "firefox" => new FirefoxDriver(Environment.CurrentDirectory),
                _ => throw new NotSupportedException($"what a browser '{Browser}'?")
            };
            //result.Manage().Window.Maximize();
            return result;
        }

        public WebDriverWait GetWait(IWebDriver driver)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(Time)) {
                PollingInterval = TimeSpan.FromMilliseconds(100)
            };
        }
    }
    
}
