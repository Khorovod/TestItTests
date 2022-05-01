using OpenQA.Selenium;
using System;
using TestItTests.Common;

namespace TestItTests.Pages.Models
{
    public class FoundVideoRow : YoutubeBasePage
    {
        private readonly Func<IWebElement> _parent;

        IWebElement Parent => _parent.Invoke();
        public FoundVideoRow(Func<IWebElement> parent)
        {
            _parent = parent;
        }

        public string Title => Parent.FindElement("#title-wrapper", Conditions.Exist).GetAttribute("value");
        public string Channel => Parent.FindElement("#channel-info #channel-name", Conditions.Visible).GetAttribute("value");

        public YoutubeVideo Open()
        {
            Parent.FindElement("#thumbnail").Click();
            WaitLoading();
            return new YoutubeVideo();
        }
    }

    public class FoundChannelRow : YoutubeBasePage
    {
        private readonly Func<IWebElement> _parent;

        IWebElement Parent => _parent.Invoke();
        public FoundChannelRow(Func<IWebElement> parent)
        {
            _parent = parent;
        }

        public string Title => Parent.FindElement(".ytd-channel-name", Conditions.Exist).Text;

        public YoutubeChannel Open()
        {
            Parent.FindElement(".channel-link").Click();
            WaitLoading();
            return new YoutubeChannel();
        }

    }
}
