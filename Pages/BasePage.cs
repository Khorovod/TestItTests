using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestItTests.Drivers;

namespace TestItTests.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver _driver;
        protected readonly WebDriverWait _wait;
        public BasePage()
        {
            _driver = SeleniumDriver.Current;
            _wait = SeleniumDriver.CurrentWait;
        }
    }
}
