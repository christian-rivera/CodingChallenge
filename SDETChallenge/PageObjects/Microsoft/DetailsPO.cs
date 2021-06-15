using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDETChallenge.PageObjects
{
    class DetailsPO
    {
        [FindsBy(How = How.ClassName, Using = "pi-price-text")]
        public IWebElement detailsPrice { get; set; }

        [FindsBy(How = How.Id, Using = "buttonPanel_AddToCartButton")]
        public IWebElement addToCartButton { get; set; }

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
            return priceToInt(detailsPrice.Text);

        }

        public void clickOnAddToCartButton()
        {
            addToCartButton.Click();
        }
    }
}
