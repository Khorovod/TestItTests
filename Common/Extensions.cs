using OpenQA.Selenium;
using System.Collections.Generic;


namespace TestItTests.Common
{
    public enum Conditions
    {
        None = 0,
        Exist = 1,
        Visible = 2,
    }

    public static class Extensions
    {

        public static IWebElement FindElement(this IWebDriver driver, string selector, Conditions condition = Conditions.None)
        {
            var el = By.CssSelector(selector);
            return driver.FindElement(el, condition);
        }
        public static IWebElement FindElement(this IWebDriver driver, By by, Conditions condition)
        {
            Wait(by, condition);
            return driver.FindElement(by);
        }
        public static IEnumerable<IWebElement> FindElements(this IWebDriver driver, string selector)
        {
            return driver.FindElements(By.CssSelector(selector));
        }

        static By Wait(string selector, Conditions condition) => Wait(By.CssSelector(selector), condition);

        static By Wait(By by, Conditions condition)
        {
            switch (condition) {
                case Conditions.None:
                    break;
                case Conditions.Exist:
                    Common.Wait.CssExist(by);
                    break;
                case Conditions.Visible:
                    break;
                default:
                    break;
            }
            return by;
        }

    }
}
