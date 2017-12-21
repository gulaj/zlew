using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionObject;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace KitchenSink.Tests.Test.SectionObject
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture(Config.Browser.Chrome)]
    [TestFixture(Config.Browser.Edge)]
    [TestFixture(Config.Browser.Firefox)]
    class NestedPartialsPageTest : BaseTest
    {
        private NestedPartialsPage _nestedPartialsPage;
        private MainPage _mainPage;

        public NestedPartialsPageTest(Config.Browser browser) : base(browser)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _nestedPartialsPage = _mainPage.GoToNestedPartialsPage();
        }

        [Test]
        public void NestedPartialsPage_AddNewChild()
        {
            WaitUntil(x => _nestedPartialsPage.ChildCompositions.Count > 0);

            var compositionsBefore = _nestedPartialsPage.ChildCompositions.Count;
            _nestedPartialsPage.AddChild();
            WaitUntil(x => _nestedPartialsPage.ChildCompositions.Count > compositionsBefore);
            var compositionsAfter = _nestedPartialsPage.ChildCompositions.Count;

            Assert.Greater(compositionsAfter, compositionsBefore);
        }
    }
}
