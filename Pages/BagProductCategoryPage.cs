using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;


namespace OnlineStoreTesting.Pages
{
    internal class BagProductCategoryPage : WatchesCategoryPage
    {
        private readonly By _removeButtonLocator = By.XPath(".//*[@class='action delete']");
        private readonly By _cartLocator = By.XPath(".//*[@class='action showcart']");
        private readonly By _addedProductsNumberLocator = By.XPath(".//*[@class='counter-number']");
        private readonly By _confirmRemoveProductFromCartLocator = By.XPath(".//*[contains(text(),'OK')]");
        private readonly By _addingItemToCartLoader = By.XPath(".//div[@class='loader']");
        private readonly By _miniCartLocator = By.Id("mini-cart");


        public BagProductCategoryPage(IWebDriver driver) : base(driver)
        {
        }
        
        public void NavigateToProductInfo(string productName)

        {
            IWebElement webElement= _driver.FindElement(By.XPath($"//li[@class='item product product-item']//a[contains(text(),'{productName}')]"));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((driver) => driver.FindElement(By.XPath($"//li[@class='item product product-item']//a[contains(text(),'{productName}')]")));
            webElement.Click();
           
        }

        public void AddToCart(string productName)
        {
            
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            IWebElement finditem = _driver.FindElement(By.XPath($"//li[@class='item product product-item']//a[contains(text(),'{productName}')]"));
            Actions actions = new Actions(_driver);
            actions.MoveToElement(finditem);
            actions.Perform();
            IWebElement productAddToCart = _driver.FindElement(By.XPath($".//a[contains(text(),'{productName}')]/parent::*/parent::*//button"));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($".//a[contains(text(),'{productName}')]/parent::*/parent::*//button")));
            productAddToCart.Click();
            wait.Until((driver) => driver.FindElements(_addingItemToCartLoader).Count == 0);

        }

        public void DeleteAllAddToCartProducts()
        {
            WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            wait.Until((driver) => driver.FindElement(_addedProductsNumberLocator));
            wait.Until(ExpectedConditions.ElementIsVisible(_addedProductsNumberLocator));
            IWebElement numberOfProducts = _driver.FindElement(_addedProductsNumberLocator);
            string number = numberOfProducts.Text;
            wait.Until((driver) => driver.FindElement(_cartLocator));
            IWebElement cart = _driver.FindElement(_cartLocator);
            cart.Click();
            ReadOnlyCollection<IWebElement> toRemove = _driver.FindElements(_removeButtonLocator);
            int expectedCount=toRemove.Count;

            while(expectedCount > 0)
                {
                    toRemove = _driver.FindElements(_removeButtonLocator);
                    var element = toRemove.First();
                    wait.Until(ExpectedConditions.ElementToBeClickable(element));
                    IWebElement webElement = _driver.FindElement(_miniCartLocator);
                    ReadOnlyCollection<IWebElement> webElements = webElement.FindElements(_removeButtonLocator);
                    webElements[0].Click();
                    wait.Until(ExpectedConditions.ElementToBeClickable(_removeButtonLocator));
                    IWebElement okButton = _driver.FindElement(_confirmRemoveProductFromCartLocator);
                    wait.Until(ExpectedConditions.ElementToBeClickable(_confirmRemoveProductFromCartLocator));
                    okButton.Click();
                   
                    expectedCount--;
                    wait.Until((driver) => driver.FindElements(_removeButtonLocator).Count == expectedCount);


                }

            }
        }


    }

