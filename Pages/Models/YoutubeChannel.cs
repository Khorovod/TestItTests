using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TestItTests.Common;
using TestItTests.Pages.Objects;

namespace TestItTests.Pages.Models
{
    public class YoutubeChannel : YoutubeBasePage
    {
        Lazy<IEnumerable<IWebElement>> lazyTabs;
        public YoutubeChannel()
        {
            lazyTabs = new Lazy<IEnumerable<IWebElement>>(() => _driver.FindElements("#tabs #tabsContent [role='tab']"));
        }
        IEnumerable<IWebElement> TabsEl => lazyTabs.Value;


        public bool IsTabSelected(string tabName)
        {
            var el = TabsEl.Single(t => t.Text.Contains(tabName.ToUpper()));
            return el.GetAttribute("aria-selected").Contains("true");
        }
        public YoutubeTabWithVideo SelectTab(string tabName)
        {
            TabsEl.Single(t => t.Text.Contains(tabName)).Click();
            WaitLoading();
            return new YoutubeTabWithVideo();
        }
    }

    public class YoutubeTabWithVideo : YoutubeBasePage
    {

        IEnumerable<IWebElement> VidsPreview => _driver.FindElements("ytd-grid-video-renderer.ytd-grid-renderer");

        public ComboboxFilter Filter => new ComboboxFilter();
        public List<VideoPreview> Videos {
            get {
                WaitLoading();
                var res = new List<VideoPreview>();
                foreach (var item in VidsPreview) {
                    res.Add(new VideoPreview(() => item));
                }
                return res;
            }
        }

        public class VideoPreview 
        {
            private readonly Func<IWebElement> _parent;

            IWebElement Parent => _parent.Invoke();
            public VideoPreview(Func<IWebElement> parent)
            {
                _parent = parent;
            }

            public string Title => Parent.FindElement("#details #video-title").GetAttribute("title");

            public YoutubeVideo Open()
            {
                Parent.FindElement("#thumbnail").Click();
                return new YoutubeVideo();
            }
        }
    }
}
