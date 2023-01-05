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
        private readonly By _addToCartLoader = By.XPath(".//div[@class='loader']");
     
        public BagInformationPage(IWebDriver driver) : base(driver)
        {
        }

        public void AddToCart()
        {
            IWebElement addToCart= _driver.FindElement(_addToCartLocator);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(_addToCartLoader));
            wait.Until(ExpectedConditions.ElementToBeClickable(_addToCartLocator));
            addToCart.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("counter-number")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(_addToCartLoader));


        }

        public int GetCartItemNumber()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement cartNumber = _driver.FindElement(_cartNumber);
            wait.Until((_driver)=> cartNumber.Text != "" && cartNumber.Text != "0");
            string number = cartNumber.Text;
            return int.Parse(number);

        }



    }
}
