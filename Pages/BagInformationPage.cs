using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;


namespace OnlineStoreTesting.Pages
{
    public class BagInformationPage : BasePage
    {
        private readonly By _addToCartLocator = By.XPath(".//span[contains(text(),'Add to Cart')]");
        private readonly By _cartNumber = By.ClassName("counter-number");
        private readonly By _removeButtonLocator = By.XPath(".//*[contains(text(),'Remove')]");

        public BagInformationPage(IWebDriver driver) : base(driver)
        {
        }

        public void AddToCart()
        {
            IWebElement addToCart= _driver.FindElement(_addToCartLocator);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(_addToCartLocator));
            addToCart.Click();
           
            Thread.Sleep(3000);
          

        }

        public int GetCartItemNumber()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement cartNumber = _driver.FindElement(_cartNumber);
            wait.Until((_driver)=> cartNumber.Text != "" && cartNumber.Text != "0");
            string number = cartNumber.Text;
            return int.Parse(number);

        }
        public void DeleteAllAddToCartProducts()
        {
            ReadOnlyCollection<IWebElement> remove = _driver.FindElements(_removeButtonLocator);
            foreach (IWebElement element in remove)
            {
                element.Click();
            }
        }


    }
}
