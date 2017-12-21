using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionCustom;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;

namespace KitchenSink.Tests.Test.SectionCustom
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture(Config.Browser.Chrome)]
    [TestFixture(Config.Browser.Edge)]
    [TestFixture(Config.Browser.Firefox)]
    class ClientLocalStateTest : BaseTest
    {
        private ClientLocalStatePage _clientLocalStatePage;
        private MainPage _mainPage;

        public ClientLocalStateTest(Config.Browser browser) : base(browser)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _clientLocalStatePage = _mainPage.GoToClientLocalStatePage();
        }

        [Test]
        public void ClientLocalStatePage_HoverListItemExpectHoveredTextToShow()
        {
            WaitUntil(x => _clientLocalStatePage.HoverableList.Displayed);

            // Hover the first item
            WaitUntil(x => _clientLocalStatePage.GetFirstHoverObservor().Displayed);
            _clientLocalStatePage.HoverFirstElement();
            WaitUntil(x => _clientLocalStatePage.GetFirstHoverObservor().Text.Contains("Hovered"));
            // hovering an item shouldn't affect the other
            Assert.False(_clientLocalStatePage.GetSecondHoverObservor().Text.Contains("Hovered"));

            System.Threading.Thread.Sleep(1000); //wait for mouse leave

            // Hover the second item
            WaitUntil(x => _clientLocalStatePage.GetSecondHoverObservor().Displayed);
            _clientLocalStatePage.HoverSecondElement();
            WaitUntil(x => _clientLocalStatePage.GetSecondHoverObservor().Text.Contains("Hovered"));
            // hovering an item shouldn't affect the other
            Assert.False(_clientLocalStatePage.GetFirstHoverObservor().Text.Contains("Hovered"));

        }
    }
}
