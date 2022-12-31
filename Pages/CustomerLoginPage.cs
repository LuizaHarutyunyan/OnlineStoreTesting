using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreTesting.Pages
{
    public class CustomerLoginPage: BasePage
    {
        private By _emailInputLocator = By.Name("login[username]");
        private By _passwordInputLocator = By.Name("login[password]");
        private By _signInFormButtonLocator = By.Id("send2");

        public CustomerLoginPage(IWebDriver driver) : base(driver)
        {

        }

        public void LogIn(string email,string password)
        {
            
            EnterEmail(email);
            EnterPassword(password);
            ClickSignInButton();

        }

        public void EnterEmail(string input)
        {
            var element = _driver.FindElement(_emailInputLocator);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            wait.Until((driver) => driver.FindElement(_emailInputLocator));
            element.SendKeys(input);

        }

        public void EnterPassword(string input)
        {
            var element = _driver.FindElement(_passwordInputLocator);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            wait.Until((driver) => driver.FindElement(_passwordInputLocator));
            element.SendKeys(input);

        }

        public void ClickSignInButton()
        {
            var element = _driver.FindElement(_signInFormButtonLocator);
            element.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));

            wait.Until((driver) => !driver.Title.StartsWith("Customer Login "));

        }

    }
}
