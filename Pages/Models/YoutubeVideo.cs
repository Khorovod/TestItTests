using OpenQA.Selenium;
using TestItTests.Common;

namespace TestItTests.Pages.Models
{
    public class YoutubeVideo : YoutubeBasePage
    {
        public YoutubeVideo()
        {
            WaitLoading();
        }

        IWebElement Vid => _driver.FindElement(".video-stream", Conditions.Visible);

        public bool IsVideo {
            get {
                _wait.Until(c => Vid);
                return true;
            }
        }
        public string Title => _driver.FindElement("#info-contents .title", Conditions.Exist).Text;
    }

}
