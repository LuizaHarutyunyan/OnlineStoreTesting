using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreTesting.Pages
{
    public class CreateNewAccountPage : BasePage
    {
        private readonly By _firstNameLocator = By.Id("firstname");
        private readonly By _lastNameLocator = By.Id("lastname");
        private readonly By _emailLocator = By.Id("email_address");
        private readonly By _passwordLocator = By.Id("password");
        private readonly By _passwordConfirmationLocator = By.Id("password-confirmation");
        private readonly By _createAnAccountButtonLocator = By.XPath(".//span[contains(text(),'Create an Account')]");
        private readonly By _emailAdressErrorMessageLocator = By.Id("email_address-error");
        public CreateNewAccountPage(IWebDriver driver) : base(driver)
        {
        }

        public void CreateAnAccount(string firstname,string lastname,string email,string password,string passwordconfirmation)
        {
            IWebElement firstName = _driver.FindElement(_firstNameLocator);
            firstName.SendKeys(firstname);
            IWebElement lastName = _driver.FindElement(_lastNameLocator);
            lastName.SendKeys(lastname);
            IWebElement newEmail = _driver.FindElement(_emailLocator);
            newEmail.SendKeys(email);
            IWebElement newpassword = _driver.FindElement(_passwordLocator);
            newpassword.SendKeys(password);
            IWebElement passwordConfirmation = _driver.FindElement(_passwordConfirmationLocator);
            passwordConfirmation.SendKeys(passwordconfirmation);
          


        }
        public void ClickCreateAnAccountButton()
        {
            IWebElement createAnAccount = _driver.FindElement(_createAnAccountButtonLocator);  
            createAnAccount.Click();
            
        }

        public string GetEmailErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            
            IWebElement emailErrorMessage = _driver.FindElement(_emailAdressErrorMessageLocator);
            wait.Until((driver) => driver.FindElement(_emailAdressErrorMessageLocator));
            return emailErrorMessage.Text;
        }

    }
}
