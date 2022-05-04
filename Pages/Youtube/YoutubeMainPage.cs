using OpenQA.Selenium;
using TestItTests.Common;

namespace TestItTests.Pages
{
    public class YoutubeMainPage : YoutubeBasePage
    {
        public YoutubeMainPage() : base()
        {
            GoToYoutube();
        }

        IWebElement SearchEl => _driver.FindElement("#search-input #search", Conditions.Exist);
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

        public YoutubeResultPage Search()
        {
            SearchBtn.Click();
            WaitLoading();
            return new YoutubeResultPage();
        }
    }
}
