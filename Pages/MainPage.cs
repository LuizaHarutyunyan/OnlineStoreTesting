using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreTesting.Pages
{
    public class MainPage : BasePage
    {
        private By _signInButtonLocator = By.ClassName("authorization-link");
        private By _createAccountButtonLocator = By.XPath(".//a[contains(text(),'Create an Account')]");
        private By _customerMenuLocator = By.XPath(".//button[@class='action switch']");
        private By _myAccountLocator = By.LinkText("My Account");

        public MainPage(IWebDriver driver) : base(driver)
        {


        }

        public CustomerLoginPage ClickSignInButton()
        {

            var element = _driver.FindElement(_signInButtonLocator);
            element.Click();
            return new CustomerLoginPage(_driver);
        }

        public void NavigateToCreateAccount()
        {
            IWebElement createAccount= _driver.FindElement(_createAccountButtonLocator);
            createAccount.Click();
            
        }

        public void NavigateToMyAccount()
        {
            IWebElement customerMenu= _driver.FindElement(_customerMenuLocator);
            customerMenu.Click();
            IWebElement myAccount = _driver.FindElement(_myAccountLocator);
            myAccount.Click();
        }
    }
}
