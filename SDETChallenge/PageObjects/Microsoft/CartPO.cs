using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDETChallenge.PageObjects
{
    class CartPO : IPageBase
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='store-cart-root']/div/div/div/section[2]/div/div/div[2]/div/span/span[2]/strong/span")]
        public IWebElement totalPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='store-cart-root']/div/div/div/section[1]/div/div/div/div/div/div[2]/div[2]/div[2]/div/span/span[2]/span")]
        public IWebElement price { get; set; }

        

        [FindsBy(How = How.CssSelector, Using = "#store-cart-root > div > div > div > section.main--1-Tv4Wkw > div > div > div > div > div > div.item-details > div.item-quantity-price > div.item-quantity > select")]
        public IWebElement itemsDropdown { get; set; }

        public int priceToInt(string value)
        {
            string numbers = value.Replace("$", "");
            numbers = numbers.Replace(".00", "");
            numbers = numbers.Replace(",", "");
            int price = int.Parse(numbers);
            return price;

        }

        public int getPrice()
        {
            return priceToInt(price.Text);

        }

        public int getTotalPrice()
        {
            
            return priceToInt(totalPrice.Text);
        }

        public void selectNumOfItems(string value)
        {
            SelectElement select = new SelectElement(itemsDropdown);
            select.SelectByText(value);
        }

    }
}
