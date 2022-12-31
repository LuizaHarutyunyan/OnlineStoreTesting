using OpenQA.Selenium;


namespace OnlineStoreTesting.Pages
{
    public class MyAccountPage : BasePage
    {
       
        private readonly By _myOrdersButtonLocator = By.XPath(".//*[contains(text(),'My Orders')]");
        private readonly By _orderTableData = By.XPath("//*[@id=\"my-orders-table\"]/tbody");
        private readonly By _viewOrdersLocator = By.XPath(".//*[contains(text(),'View Order')]");
     

        public MyAccountPage(IWebDriver driver) : base(driver)
        {

        }


        public void NavigateToMyOrders()
        {
            IWebElement element = _driver.FindElement(_myOrdersButtonLocator);
            element.Click();
        }
        public  void CheckMyOrders()
        {
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> webElements = _driver.FindElements((_orderTableData));
            
            webElements.Where(i => i.Equals(new OrderInformationPage(_driver).GetNumber));

        }
        public void ViewOrders()
        {
            IWebElement viewOrders = _driver.FindElement(_viewOrdersLocator);
            viewOrders.Click();
           
        }

      
    }
}

