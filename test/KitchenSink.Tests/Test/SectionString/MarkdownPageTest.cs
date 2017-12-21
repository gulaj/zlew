using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionString;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;

namespace KitchenSink.Tests.Test.SectionString
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture(Config.Browser.Edge)]
    [TestFixture(Config.Browser.Firefox)]
    class MarkdownPageTest : BaseTest
    {
        private MarkdownPage _markdown;
        private MainPage _mainPage;

        public MarkdownPageTest(Config.Browser browser) : base(browser)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _markdown = _mainPage.GoToMarkdownPage();
        }

        [Test]
        public void MarkdownPage_CheckPreviewText()
        {
            WaitUntil(x => _markdown.JuicyMarkdown.Displayed);

            Assert.AreEqual("This is a structured text", _markdown.GetHeaderText());
        }
    }
}
