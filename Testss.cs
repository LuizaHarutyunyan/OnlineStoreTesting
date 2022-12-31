using NUnit.Framework;
using OnlineStoreTesting.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace OnlineStoreTesting
{
    public class Testss
    {
        [ThreadStatic]
        private static MainPage _mainPage;
        private static BasePage _basePage;
        private static WatchesCategoryPage _watchesCategoryPage;
        private static ShippingPage _shippingPage;
        private static OrderInformationPage _orderInformationPage;
        private static MyAccountPage _myAccountPage;
        private static OrderPage _orderPage;
        private static CreateNewAccountPage _createNewAccountPage;
        private static BagProductCategoryPage _bagProductCategoryPage;
        private static CustomerLoginPage _customerLoginPage;
        private static BagInformationPage _bagInformationPage;

        [ThreadStatic]
        private static IWebDriver _driver;
        
        [SetUp]
        public void SetUp()
        {
            
            _driver= new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://magento.softwaretestingboard.com/");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            _mainPage = new MainPage(_driver);
            _basePage = new BasePage(_driver);
            _watchesCategoryPage = new WatchesCategoryPage(_driver);
            _shippingPage= new ShippingPage(_driver);
            _orderInformationPage = new OrderInformationPage(_driver);
            _myAccountPage= new MyAccountPage(_driver);
            _orderPage = new OrderPage(_driver);
            _createNewAccountPage= new CreateNewAccountPage(_driver);
            _bagProductCategoryPage = new BagProductCategoryPage(_driver);
            _customerLoginPage = new  CustomerLoginPage(_driver);
            _bagInformationPage= new BagInformationPage(_driver);
            



        }

      
        [Test]
        public void First_Scenario()
        {
          _mainPage.ClickSignInButton();
            
           _customerLoginPage.LogIn("louisa.harutyunyan.98@gmail.com", "test_password12");
            _basePage.OpenWatchesCategoryPage();
            _watchesCategoryPage.AddToCart("Dash Digital Watch");
            _watchesCategoryPage.ClickCartButton();
            _watchesCategoryPage.ClickProceedToCheckoutButton();
            
            _shippingPage.AddNewAdress();
            
            _shippingPage.ShippingAdressFill("SPUR ROAD", "lONDON", "SW1A 1AA");
            _shippingPage.Skip();
            _shippingPage.ChooseShippingMethod();
            _shippingPage.NextPage();
            _orderInformationPage.PlaceOrder();
            _orderInformationPage.GetNumber();
            _orderInformationPage.ContniueShopping();
            _basePage.OpenMyAccount();
            _myAccountPage.NavigateToMyOrders();
            _myAccountPage.CheckMyOrders();
            _myAccountPage.ViewOrders();
            if (_orderPage.CheckProductName() == "Dash Digital Watch")
            {
                Assert.AreEqual(_orderPage.SubPriceCheck(), _orderPage.GrandTotalPriceCheck());
               
            }
            
        }



        [Test]
        public void Second_Scenario()
        {
            _mainPage.NavigateToCreateAccount();
           
            _createNewAccountPage.CreateAnAccount("Luiza","Harutyunyan",String.Empty,"test_password12", "test_password12");
            
            _createNewAccountPage.ClickCreateAnAccountButton();
         
            _createNewAccountPage.GetEmailErrorMessage();
           
            Assert.AreEqual(_createNewAccountPage.GetEmailErrorMessage(), "This is a required field.");
           
        }
        [Test]
        public void Third_Scenario()
        {
            _mainPage.ClickSignInButton();
            _customerLoginPage.LogIn("louisa.harutyunyan.98@gmail.com", "test_password12");
            _basePage.OpenGearCategoryPage();
            
            _bagProductCategoryPage.NavigateToBags();

            _bagProductCategoryPage.DeleteAllAddToCartProducts();
            
            _bagProductCategoryPage.AddToCart();
            _bagProductCategoryPage.NavigateToProductInfo();
            
            _bagInformationPage.AddToCart();
            Assert.AreEqual(_bagInformationPage.GetCartItemNumber(), 3);
          


        }


        [TearDown]
        public void TearDown()
        {
           
            _driver.Quit();

        
        }
    }
}
