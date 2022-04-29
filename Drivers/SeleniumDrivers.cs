using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestItTests.Drivers
{
    public static class SeleniumDrivers
    {
        [ThreadStatic]
        static IWebDriver _driver;

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("where is driver?");
        public static void Init(string browser)
        {
            switch (browser)
            {
                case "chrome":
                    _driver = new ChromeDriver(Environment.CurrentDirectory);
                    break;
                default:
                    break;
            }
        }

        public static void Quit()
        {
            Current.Quit();
        }
    }
}
