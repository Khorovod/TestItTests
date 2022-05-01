using NUnit.Framework;
using TestItTests.Drivers;

namespace TestItTests
{
    abstract internal class TestBase
    {
        [OneTimeSetUp]
        public virtual void BeforeAll()
        {
        
        }

        [SetUp]
        public virtual void Setup()
        {
            SeleniumDriver.CreateDriverAndWait();
        }

        [TearDown]
        public virtual void TearDown()
        {
            SeleniumDriver.Quit();
        }
    }
}
