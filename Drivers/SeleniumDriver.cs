using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using TestItTests.Common;

namespace TestItTests.Drivers
{
    public static class SeleniumDriver
    {
        [ThreadStatic]
        static IWebDriver _driver;
        [ThreadStatic]
        static WebDriverWait _wait;

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("where is the driver?");
        public static WebDriverWait CurrentWait => _wait ?? throw new NullReferenceException("where is the wait?");

        public static void CreateDriverAndWait()
        {
            var factory = new DriverFactory();
            _driver = factory.Build();
            _wait = factory.GetWait(_driver);
        }
        public static void TakeScreenshot(string imageName)
        {
            var ss = ((ITakesScreenshot)Current).GetScreenshot();
            var ssFileName = Path.Combine(Config.DIRECTORY + "TestResults", imageName);
            ss.SaveAsFile($"{ssFileName}.png", ScreenshotImageFormat.Png);
        }

        public static DirectoryInfo CreateOutputDirectory()
        {
            var testDirectory = Config.DIRECTORY + "TestResults";

            if (Directory.Exists(testDirectory)) {
                Directory.Delete(testDirectory, recursive: true);
            }

            return Directory.CreateDirectory(testDirectory);
        }

        public static void Quit()
        {
            Current.Quit();
        }
    }
}
