using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreTesting.Pages
{
    public class OrderPage : BasePage
    {
        private readonly By _productName = By.XPath("//*[@class='product name product-item-name']");
        private readonly By _subPrice = By.XPath("//*[@class='amount' and @data-th='Subtotal']//span");
        private readonly By _shipping = By.XPath("//*[@class='amount' and @data-th='Shipping & Handling']//span");
        private readonly By _grandTotal = By.XPath("//*[@data-th='Grand Total']");


        public OrderPage(IWebDriver driver) : base(driver)
        {

        }

        public string CheckProductName()
        {
            IWebElement productName = _driver.FindElement(_productName);
            string name = productName.Text;
            return name;
        }

        public string SubPriceCheck()
        {
            IWebElement subPrice = _driver.FindElement(_subPrice);
            string subprice = subPrice.Text.Trim('$');
            IWebElement shipping = _driver.FindElement(_shipping);
            string ship = shipping.Text.Trim('$');
            decimal shippingPrice = decimal.Parse(ship);
            decimal subprice1 = decimal.Parse(subprice);
            decimal totalPrice = shippingPrice + subprice1;
            return totalPrice.ToString();

        }
        public string GrandTotalPriceCheck()
        {
            IWebElement grandTotal = _driver.FindElement(_grandTotal);
            string total = grandTotal.Text.Trim('$');
            return total;

        }


    }
}
