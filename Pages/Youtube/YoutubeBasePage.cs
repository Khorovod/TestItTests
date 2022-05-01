using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
