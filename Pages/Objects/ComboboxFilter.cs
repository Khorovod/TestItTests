using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestItTests.Common;

namespace TestItTests.Pages.Objects
{
    public class ComboboxFilter : BasePage
    {
        IWebElement FilterEl => _driver.FindElement("#sort-menu", Conditions.Exist);
        bool IsDropdownHidden => FilterEl.FindElement("#dropdown", Conditions.Exist).GetAttribute("aria-hidden") is null ? false : true;
        bool IsFilterSelected(string filterName) => FilterRows.First(r => r.Text.Equals(filterName)).GetAttribute("aria-selected").Contains("true");
        IEnumerable<IWebElement> FilterRows => FilterEl.FindElements("#menu .yt-simple-endpoint", Conditions.AllElementsPresence);


        public List<string> Filters => FilterRows.Select(f => f.Text).ToList();

        public void Popular() => SelectFilter("Самые популярные");
        public void NewFirst() => SelectFilter("Дата добавления: сначала новые");
        public void OldFirts() => SelectFilter("Дата добавления: сначала старые");

        private void SelectFilter(string name)
        {
            if (IsDropdownHidden) {
                FilterEl.Click();
                //
                Thread.Sleep(100);
            }
            if(!IsFilterSelected(name)) {
                FilterRows.First(r => r.Text.Equals(name)).Click();
            }
        }
    }
}
