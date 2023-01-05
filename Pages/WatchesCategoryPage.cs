using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace OnlineStoreTesting.Pages
{
    public class WatchesCategoryPage : BasePage
    {
        private By _cartButtonLocator = By.XPath(".//a[@class='action showcart']");
        private By _proceedToCheckout = By.XPath("//*[@id='top-cart-btn-checkout']");
        private By _numberOfItemsLocator = By.XPath(".//span[@class='counter qty']/parent::a[@class='action showcart']");
        private By _bagsButtonLocator = By.XPath(".//a[contains(text(),'Bags')]");
        private readonly By _addingItemToCartLoader = By.XPath(".//div[@class='loader']");
        public WatchesCategoryPage(IWebDriver driver) : base(driver)
        {

        }
       

        public void AddToCart(string productName)
        {

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            IWebElement finditem = _driver.FindElement(By.XPath($"//li[@class='item product product-item']//img[@alt='{productName}']"));
            Actions actions = new Actions(_driver);
            actions.MoveToElement(finditem);
            actions.Perform();
            IWebElement productAddToCart = _driver.FindElement(By.XPath($".//a[contains(text(),'{productName}')]/parent::*/parent::*//button"));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($".//a[contains(text(),'{productName}')]/parent::*/parent::*//button")));
            productAddToCart.Click();

        }

        public void ClickProceedToCheckoutButton()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((driver) => driver.FindElement(_proceedToCheckout));
            IWebElement checkoutButton = _driver.FindElement(_proceedToCheckout);
            checkoutButton.Click();

        }
        public void ClickCartButton()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((driver) => driver.FindElement(_cartButtonLocator));
            IWebElement cartButton = _driver.FindElement(_cartButtonLocator);
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(_addingItemToCartLoader));
            IWebElement numberOfItems = _driver.FindElement(_numberOfItemsLocator);
            wait.Until(ExpectedConditions.ElementIsVisible(_numberOfItemsLocator));
            cartButton.Click();
        }
        public void NavigateToBags()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement bagsCategoryButton = _driver.FindElement(_bagsButtonLocator);
            wait.Until((driver) => driver.FindElement(_bagsButtonLocator));
            bagsCategoryButton.Click();
        }

    }
}
