using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests.Ui.SectionObject
{
    public class NestedPartialsPage : BasePage
    {
        public NestedPartialsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Add child']")]
        public IWebElement AddChildButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//juicy-composition")]
        public IList<IWebElement> ChildCompositions { get; set; }

        public void AddChild()
        {
            ClickOn(AddChildButton);
        }
    }
}
