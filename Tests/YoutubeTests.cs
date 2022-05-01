using NUnit.Framework;
using System.Linq;
using TestItTests.Pages;

namespace TestItTests
{

    class YoutubeTests : TestBase
    {

        [Test]
        [Parallelizable]
        public void ПоЗапросу_Test_It_ЮтубВыдаетКанал_Test_It()
        {
            var query = "Test IT";
            var yt = new YoutubeMainPage();

            yt.SearchField = query;
            Assert.AreEqual(yt.SearchField, query);
            var result = yt.Search();

            Assert.IsTrue(result.Channels.Select(c => c.Title).Any(c => c.Equals(query)));
        }

        [Test]
        [Parallelizable]
        public void НаКанале_Test_It_ОтфильтрованоПоДатеДобавленияОткрываетсяВидео7()
        {
            var query = "Test IT";
            var yt = new YoutubeMainPage();

            yt.SearchField = query;
            var result = yt.Search();
            var channel = result.Channels.First().Open();

            Assert.IsTrue(channel.IsTabSelected("ГЛАВНАЯ"));
            var tab = channel.SelectTab("ВИДЕО");

            tab.Filter.OldFirts();
            var preview = tab.Videos.Skip(6).First();
            var title = preview.Title;
            var video = preview.Open();

            Assert.IsTrue(video.Title.Contains(title), $"Titles didnt match\r\nExpected '{title}'\r\nBut was '{video.Title}'");
            Assert.IsTrue(video.IsVideo);
        }
    }
}
