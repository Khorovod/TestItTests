using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestItTests.Common;
using TestItTests.Drivers;

namespace TestItTests
{
    abstract class StartUp
    {

        [SetUp]
        public virtual void Setup()
        {
            var browser = new Config().Configure.Driver.Browser;
            SeleniumDrivers.Init(browser);
        }

        [OneTimeTearDown]
        public virtual void TearDown()
        {
            SeleniumDrivers.Quit();
        }
    }
}
