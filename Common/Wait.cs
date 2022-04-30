using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TestItTests.Drivers;

namespace TestItTests.Common
{
    public static class Wait
    {
        public static By CssExist(By by)
        {
            try {
                SeleniumDriver.CurrentWait.Until(ExpectedConditions.ElementExists(by));
                return by;
            }
            catch (Exception) {

                throw;
            }
        }

        public static bool Until(Func<IWebDriver, bool> condition)
        {
            return SeleniumDriver.CurrentWait.Until(condition);
        }

        public static IWebElement Until(Func<IWebDriver, IWebElement> condition)
        {
            return SeleniumDriver.CurrentWait.Until(condition);
        }
    }
}
