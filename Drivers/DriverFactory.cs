using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using TestItTests.Common;

namespace TestItTests.Drivers
{
    public class DriverFactory
    {
        MyConfig.DriverSettings Driver => new Config().Configure.Driver;
        string Browser => Driver.Browser;
        int Time => Driver.WaitSeconds;

        readonly string _proxyAdress = "199.60.103.81:80";

        //опять что-то заблокировали, превьюшки не качаются, ютуб не возвращает полностью загруженные страницы, а прокси завести не удалось:)
        ChromeOptions Options()
        {
            var opt = new ChromeOptions();
            var proxy = new Proxy();
            proxy.HttpProxy = _proxyAdress;
            //proxy.SslProxy = _proxyAdress;
            proxy.Kind = ProxyKind.Manual;
            opt.Proxy = proxy;

            return opt;
        }

        public IWebDriver Build()
        {
            IWebDriver result;
            result = Browser switch {
                //"chrome" => new ChromeDriver(Environment.CurrentDirectory, Options()),
                "chrome" => new ChromeDriver(Environment.CurrentDirectory),
                "firefox" => new FirefoxDriver(Environment.CurrentDirectory),
                _ => throw new NotSupportedException($"what a browser '{Browser}'?")
            };
            //result.Manage().Window.Maximize();
            return result;
        }

        public WebDriverWait GetWait(IWebDriver driver)
        {
            WebDriverWait wait;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Time)) {
                PollingInterval = TimeSpan.FromMilliseconds(200)
            };
            wait.IgnoreExceptionTypes(
                typeof(NoSuchElementException),
                typeof(ElementNotVisibleException),
                typeof(StaleElementReferenceException));
            return wait;
        }
    }
    
}
