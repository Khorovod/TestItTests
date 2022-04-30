using OpenQA.Selenium;
using System;
using TestItTests.Common;

namespace TestItTests.Pages
{
    public class YoutubeMainPage : BasePage
    {
        public YoutubeMainPage() : base()
        {
            if (!_driver.Url.Contains("youtube")) 
            {
                _driver.Navigate().GoToUrl("https://www.youtube.com/");
            }
        }

        bool LoadingCompleteEl => _driver.FindElement("yt-page-navigation-progress").GetAttribute("aria-valuenow").Contains("100");
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
            Wait.Until(c => LoadingCompleteEl);
            return new YoutubeResultPage();
        }
    }
}
