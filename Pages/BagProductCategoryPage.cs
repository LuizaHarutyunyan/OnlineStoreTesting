using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OnlineStoreTesting.Pages
{
    internal class BagProductCategoryPage : WatchesCategoryPage
    {
        private readonly By _bagsLoactor = By.XPath("(.//*[@class='item product product-item'])[3]");
        private readonly By _addToCartLocatorOfFirstBag = By.XPath("(.//*[contains(text(),'Add to Cart')])[1]");
        private readonly By _findFirstBagLocator = By.XPath("(.//*[@class='item product product-item'])[1]");
        private readonly By _addToCartLocatorOfSecondBag = By.XPath("(.//*[contains(text(),'Add to Cart')])[2]");
        private readonly By _findSecondBagLoactor = By.XPath("(.//*[@class='item product product-item'])[2]");
        private readonly By _removeButtonLocator = By.XPath(".//*[@title='Remove item']");
        private readonly By _cartLocator = By.XPath(".//*[@class='action showcart']");
        private readonly By _addedProductsNumberLocator = By.XPath(".//*[@class='counter-number']");
        private readonly By _confirmRemoveProductFromCartLocator = By.XPath(".//*[contains(text(),'OK')]");


        public BagProductCategoryPage(IWebDriver driver) : base(driver)
        {
        }
        
        public void NavigateToProductInfo()

        {
            IWebElement webElement= _driver.FindElement(_bagsLoactor);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((driver) => driver.FindElement(_bagsLoactor));
            webElement.Click();
           
        }

        public void AddToCart()
        {
            IWebElement firstBag = _driver.FindElement(_findFirstBagLocator);
            Actions action1 = new Actions(_driver);
            action1.MoveToElement(firstBag);
            action1.Perform();
            IWebElement addToCart1 = _driver.FindElement(_addToCartLocatorOfFirstBag);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click()", addToCart1);
            

            IWebElement secondBag = _driver.FindElement(_findSecondBagLoactor);
            Actions action2 = new Actions(_driver);
            action2.MoveToElement(secondBag);
            action2.Perform();
            IWebElement addToCart2 = _driver.FindElement(_addToCartLocatorOfSecondBag);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click()", addToCart2);
        }

        public void DeleteAllAddToCartProducts()
        {
            WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            wait.Until((driver) => driver.FindElement(_addedProductsNumberLocator));
            IWebElement numberOfProducts = _driver.FindElement(_addedProductsNumberLocator);
            Thread.Sleep(3000);
            string number = numberOfProducts.Text;
            if (true)
            {
              
                wait.Until((driver) => driver.FindElement(_cartLocator));
                IWebElement cart = _driver.FindElement(_cartLocator);
                cart.Click();
                ReadOnlyCollection<IWebElement> remove = _driver.FindElements(_removeButtonLocator);
                foreach (IWebElement element in remove)
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(element));
                    IWebElement webElement = _driver.FindElement(By.XPath("//*[@id='mini-cart']"));
                    ReadOnlyCollection<IWebElement> webElements = webElement.FindElements(By.XPath(".//*[@class='action delete']"));
                    webElements[0].Click();
                    wait.Until(ExpectedConditions.ElementToBeClickable(_removeButtonLocator));

                   
                    IWebElement okButton = _driver.FindElement(_confirmRemoveProductFromCartLocator);
                    okButton.Click();
                    wait.Until((driver) => driver.FindElement(_removeButtonLocator));
                    Thread.Sleep(3000);
                   



                }
            }
        }


    }
}
