using OpenQA.Selenium;
using TestItTests.Common;

namespace TestItTests.Pages
{
    public class YoutubePage : BasePage
    {
        public YoutubePage(IWebDriver driver) : base(driver) { }

        IWebElement SearchEl => _driver.FindElement("#search-input #search");
        IWebElement SearchBtn => _driver.FindElement("#search-icon-legacy");

        public string SearchField
        {
            get => SearchEl.GetAttribute("value");
            set
            {
                SearchEl.Click();
                SearchEl.Clear();
                SearchEl.SendKeys(value);
            }
        }

        public void Search()
        {
            SearchBtn.Click();
        }
    }
}
