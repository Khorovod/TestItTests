using OpenQA.Selenium;
using System.Collections.Generic;


namespace TestItTests.Common
{
    public enum Conditions
    {
        None = 0,
        Exist = 1,
        Visible = 2,
        AllElementsPresence = 3
    }

    public static class Extensions
    {

        public static IWebElement FindElement(this IWebDriver driver, string selector, Conditions condition = Conditions.None)
        {
            var el = By.CssSelector(selector);
            return FindElement(driver, el, condition);
        }

        public static IWebElement FindElement(this IWebElement element, string selector, Conditions condition = Conditions.None)
        {
            var el = By.CssSelector(selector);
            return FindElement(element, el, condition);
        }
        public static IWebElement FindElement(ISearchContext context, By by, Conditions condition)
        {
            Wait(by, condition);
            return context.FindElement(by);
        }
        public static IEnumerable<IWebElement> FindElements(this IWebDriver driver, string selector, Conditions conditions = Conditions.None)
        {
            return FindElements(driver as ISearchContext, selector, conditions);
        }
        public static IEnumerable<IWebElement> FindElements(this IWebElement element, string selector, Conditions conditions = Conditions.None)
        {
            return FindElements(element as ISearchContext, selector, conditions);
        }
        static IEnumerable<IWebElement> FindElements(ISearchContext context, string selector, Conditions conditions)
        {
            var by = By.CssSelector(selector);
            Wait(by, conditions);
            return context.FindElements(by);
        }
        static By Wait(By by, Conditions condition)
        {
            switch (condition) {
                case Conditions.None:
                    break;
                case Conditions.Exist:
                    Common.Wait.CssExist(by);
                    break;
                case Conditions.Visible:
                    Common.Wait.CssVisible(by);
                    break;
                case Conditions.AllElementsPresence:
                    Common.Wait.AllElementsPresence(by);
                    break;
                default:
                    break;
            }
            return by;
        }

    }
}
