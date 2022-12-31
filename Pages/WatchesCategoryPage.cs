using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace OnlineStoreTesting.Pages
{
    public class WatchesCategoryPage : BasePage
    {
        private By _productLocator = By.XPath("//li[@class='item product product-item']");
        private By _addToCartButtonLocator = By.XPath("(.//button[@title='Add to Cart'])[5]");
        private By _cartButtonLocator = By.XPath(".//a[@class='action showcart']");
        private By _proceedToCheckout = By.XPath("//*[@id='top-cart-btn-checkout']");
        private By _numberOfItemsLocator = By.XPath(".//a[@href='https://magento.softwaretestingboard.com/checkout/cart/']//span[@class='counter qty']");
        private By _bagsButtonLocator = By.XPath(".//a[contains(text(),'Bags')]");
        public WatchesCategoryPage(IWebDriver driver) : base(driver)
        {

        }
       

        public void AddToCart(string productName)
        {
           
            IWebElement product = _driver.FindElement(_productLocator);
            Actions actions = new Actions(_driver);
            actions.MoveToElement(product);
            actions.Perform();
            IWebElement addToCart = _driver.FindElement(_addToCartButtonLocator);
           ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click()", addToCart);
            

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
            Thread.Sleep(2000);
            IWebElement cartButton = _driver.FindElement(_cartButtonLocator);
           IWebElement numberOfItems = _driver.FindElement(_numberOfItemsLocator);
            wait.Until((driver) => numberOfItems.GetAttribute("class") == "counter qty");
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
