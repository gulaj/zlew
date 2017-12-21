using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests.Ui.SectionCustom
{
    public class AutoCompletePage : BasePage
    {
        public AutoCompletePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "kitchensink-test-autocomplete-products-input")]
        public IWebElement ProductsInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "kitchensink-test-autocomplete-places-input")]
        public IWebElement PlaceInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "kitchensink-test-autocomplete-products-item")]
        public IList<IWebElement> ProductsAutoComplete { get; set; }

        [FindsBy(How = How.ClassName, Using = "kitchensink-test-autocomplete-places-item")]
        public IList<IWebElement> PlacesAutoComplete { get; set; }

        [FindsBy(How = How.ClassName, Using = "kitchensink-test-autocomplete-capital")]
        public IWebElement PlaceInfoLabel { get; set; }

        [FindsBy(How = How.ClassName, Using = "kitchensink-test-autocomplete-price")]
        public IWebElement ProductsInfoLabel { get; set; }

        public void ChoosePlace(string place)
        {
            ClickOn(PlacesAutoComplete.First(x => x.Text == place));
        }

        public void ChooseProducts(string product)
        {
            ClickOn(ProductsAutoComplete.First(x => x.Text == product));
        }
    }
}
