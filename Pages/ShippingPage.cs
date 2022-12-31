using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace OnlineStoreTesting.Pages
{
    public class ShippingPage : BasePage
    {
        private readonly By _streetAdressLocator = By.Name("street[0]");
        private readonly By _cityNameLocator = By.Name("city");
        private readonly By _postaclCodeLocator = By.Name("postcode");
        private readonly By _countryLocator = By.Name("country_id");
        private readonly By _phoneNumberLocator = By.Name("telephone");
        private readonly By _nextButtonLocator = By.XPath("//*[@id='shipping-method-buttons-container']/div");
        private readonly By _addNewAdressLocator = By.XPath(".//*[@class='action action-show-popup']");
        private readonly By _skippButtonLocator = By.ClassName("action-save-address");
        private readonly By _shippingMethod = By.Name("ko_unique_3");


        public ShippingPage(IWebDriver driver) : base(driver)
        {
        }
         static Random random = new Random();
        public void ShippingAdressFill(string streetAdressInput, string cityInput, string postalCodeInput)
        {
            
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((_driver)=>_driver.FindElement(_streetAdressLocator));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_streetAdressLocator));
            IWebElement streetAdress = _driver.FindElement(_streetAdressLocator);
            streetAdress.SendKeys(streetAdressInput);
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_streetAdressLocator));
            IWebElement city = _driver.FindElement(_cityNameLocator);
            city.SendKeys(cityInput);
            IWebElement postalCode = _driver.FindElement(_postaclCodeLocator);
            postalCode.SendKeys(postalCodeInput);
            IWebElement phoneNumber = _driver.FindElement(_phoneNumberLocator);
            phoneNumber.SendKeys(random.Next().ToString());
            IWebElement province = _driver.FindElement(_countryLocator);
            SelectElement select = new SelectElement(province);
            select.SelectByText("United Kingdom");
         
            
        }

        public void NextPage()
        {
            IWebElement nextButton = _driver.FindElement(_nextButtonLocator);
             WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            wait.Until((driver) => driver.FindElement(_nextButtonLocator));
            nextButton.Click();
        }


        public void AddNewAdress()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_addNewAdressLocator));
            IWebElement addNewAdress = _driver.FindElement(_addNewAdressLocator) ;
            wait.Until((_driver) => _driver.FindElement(_addNewAdressLocator).Displayed);
            wait.Until(ExpectedConditions.ElementToBeClickable(_addNewAdressLocator));
            Thread.Sleep(3000);
            addNewAdress.Click();
            Thread.Sleep(3000);
           
        }
        public void Skip()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            IWebElement skipButton = _driver.FindElement(_skippButtonLocator);
            wait.Until((driver) => driver.FindElement(_skippButtonLocator));
            skipButton.Click();
        }
        public void ChooseShippingMethod()
        {
            IWebElement shippingMethod = _driver.FindElement(_shippingMethod);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            shippingMethod.Click();
        }

        
    }
}
