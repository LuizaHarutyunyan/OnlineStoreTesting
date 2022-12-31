using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace OnlineStoreTesting.Pages
{
    internal class OrderInformationPage : BasePage
    {
        private readonly By _placeOrderButtonLocator = By.XPath(".//button[@title='Place Order']");
        private readonly By _orderNumberLocator = By.ClassName("order-number");
        private readonly By _continueShoppingLoactor = By.XPath(".//*[contains(text(),'Continue Shopping')]");
       
        public OrderInformationPage(IWebDriver driver) : base(driver)
        {

        }

        public void PlaceOrder()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until((driver) => driver.FindElement(_placeOrderButtonLocator));
            IWebElement element = _driver.FindElement(_placeOrderButtonLocator);
            wait.Until(ExpectedConditions.ElementToBeClickable(_placeOrderButtonLocator));
            Thread.Sleep(3000);
            element.Click();
            wait.Until((driver) => driver.Navigate());

        }
        public void GetNumber()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(3000);
            IWebElement element = _driver.FindElement(_orderNumberLocator);
            string getOrderNumber = element.Text;
            
        }
        public void ContniueShopping()
        {

            IWebElement continueElement = _driver.FindElement(_continueShoppingLoactor);
            continueElement.Click();
        }

      
    }
}
