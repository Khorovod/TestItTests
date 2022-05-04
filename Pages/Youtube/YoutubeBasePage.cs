using OpenQA.Selenium;
using System;
using TestItTests.Common;

namespace TestItTests.Pages
{
    public class YoutubeBasePage : BasePage
    {
        bool LoadingCompleteEl => _driver.FindElement("yt-page-navigation-progress.ytd-app").GetAttribute("aria-valuenow").Contains("100");

        protected void WaitLoading()
        {
            Wait.Until(c => LoadingCompleteEl == true);
        }

        protected void GoToYoutube()
        {
            if (!_driver.Url.Contains("youtube")) {
                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(12);
                try {
                    _driver.Navigate().GoToUrl("https://www.youtube.com");
                }
                catch (WebDriverTimeoutException) {

                    Console.WriteLine("Все еще заблокирован гугл, не ждали завершения загрузки страницы");
                }
            }
        }
    }
}
