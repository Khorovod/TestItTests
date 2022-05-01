using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestItTests.Common;
using TestItTests.Pages.Models;

namespace TestItTests.Pages
{
    public class YoutubeResultPage : YoutubeBasePage
    {

        List<IWebElement> VideosList => _driver.FindElements("#dismissible.style-scope.ytd-video-renderer").ToList();
        List<IWebElement> ChannelsList => _driver.FindElements("ytd-channel-renderer.ytd-item-section-renderer").ToList();

        public List<FoundVideoRow> Videos {
            get {
                var res = new List<FoundVideoRow>();
                foreach (var vid in VideosList) {
                    res.Add(new FoundVideoRow(() => vid));
                }
                return res;
            }
        }

        public List<FoundChannelRow> Channels {
            get {
                var res = new List<FoundChannelRow>();
                foreach (var channel in ChannelsList) {
                    res.Add(new FoundChannelRow(() => channel));
                }
                return res;
            }
        }
    }
}
