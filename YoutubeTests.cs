using NUnit.Framework;
using TestItTests.Pages;

namespace TestItTests
{

    class YoutubeTests : TestBase
    {

        [Test]
        [Parallelizable]
        public void ПоЗапросу_Test_It_ЮтубВыдаетКанал_Test_It()
        {
            var yt = new YoutubeMainPage();

            yt.SearchField = "Test IT";
            Assert.AreEqual(yt.SearchField, "Test IT");
            yt.Search();
        }

        [Test]
        [Parallelizable]
        public void НаКанале_Test_It_ОтфильтрованоПоДатеДобавленияОткрываетсяВидео7()
        {
            var yt = new YoutubeMainPage();

            yt.SearchField = "Test IT";
            yt.Search();
        }
    }
}
