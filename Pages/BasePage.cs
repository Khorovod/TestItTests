using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestItTests.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver _driver;
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
