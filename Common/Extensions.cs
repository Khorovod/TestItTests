using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestItTests.Common
{
    public static class Extensions
    {

        public static IWebElement FindElement(this IWebDriver driver, string selector)
        {
            return driver.FindElement(By.CssSelector(selector));
        }
    }
}
