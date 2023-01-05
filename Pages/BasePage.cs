using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreTesting.Pages
{
    public class BasePage
    {
        private By _gearCategoryButtonLocator = By.Id("ui-id-6");
        private By _watchesCategoryButtonLocator = By.XPath("//*[@id='ui-id-27']");

        protected readonly IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public WatchesCategoryPage OpenGearCategoryPage()
        {
            var element = _driver.FindElement(_gearCategoryButtonLocator);
            element.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            wait.Until((driver) => driver.Title.StartsWith("Gear"));
            return new WatchesCategoryPage(_driver);
        }

        public WatchesCategoryPage OpenWatchesCategoryPage()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            var element = _driver.FindElement(_gearCategoryButtonLocator);
            Actions actions = new Actions(_driver);
            actions.MoveToElement(element);
            actions.Perform();
            IWebElement watchesButton = element.FindElement(_watchesCategoryButtonLocator);
            wait.Until((driver) => driver.FindElement(_watchesCategoryButtonLocator));
            wait.Until(ExpectedConditions.ElementToBeClickable(_watchesCategoryButtonLocator));
            watchesButton.Click();
            wait.Until((driver) => driver.Title.StartsWith("Watches"));
            return new WatchesCategoryPage(_driver);
        }

    }
}
