using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TestItTests.Drivers;

namespace TestItTests
{
    abstract internal class TestBase
    {
        [OneTimeSetUp]
        public virtual void BeforeAll()
        {
            SeleniumDriver.CreateOutputDirectory();
        }

        [SetUp]
        public virtual void Setup()
        {
            SeleniumDriver.CreateDriverAndWait();
        }

        [TearDown]
        public virtual void TearDown()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;

            if (outcome == TestStatus.Failed) {
                SeleniumDriver.TakeScreenshot(TestContext.CurrentContext.Test.Name);
            }
            SeleniumDriver.Quit();
        }
    }
}
