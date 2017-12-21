using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;

namespace KitchenSink.Tests.Ui.SectionCustom
{
    public class ClientLocalStatePage : BasePage
    {
        public ClientLocalStatePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-clientlocalstatepage-hoverable-list")]
        public IWebElement HoverableList { get; set; }

        [FindsBy(How = How.TagName, Using = "hover-observer")]
        public IList<IWebElement> HoverObservors { get; set; }

        public void HoverFirstElement()
        {
            /* Hover can only be acheived by Selenium Actions. 
             * Firefox doesn't support Selenium actions, this is JS/Polymer walkaround */
            string command = 
                "const item = document.querySelectorAll('hover-observer')[0];" +
                "item.fire('mouseenter');" +
                "setTimeout(()=> item.fire('mouseleave'), 500)";
            ((IJavaScriptExecutor)Driver).ExecuteScript(command);
        }
        public void HoverSecondElement()
        {
            string command =
                "const item = document.querySelectorAll('hover-observer')[1];" +
                "item.fire('mouseenter');" +
                "setTimeout(()=> item.fire('mouseleave'), 500)";
            ((IJavaScriptExecutor)Driver).ExecuteScript(command);
        }
        public IWebElement GetFirstHoverObservor()
        {
            return HoverObservors[0];            
        }
        public IWebElement GetSecondHoverObservor()
        {
            return HoverObservors[1];
        }
    }
}
