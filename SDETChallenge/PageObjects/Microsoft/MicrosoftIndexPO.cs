using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDETChallenge.PageObjects
{
    public class MicrosoftIndexPO : IPageBase
    {
        [FindsBy(How=How.ClassName,Using = "uhf-menu-item")]
        public IList<IWebElement> menuItems { get; set; }

        [FindsBy(How = How.Id, Using = "shellmenu_2")]
        public IWebElement windowsMenuOption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span[itemprop='price']")]
        public IList<IWebElement> priceItems { get; set; }

        [FindsBy(How = How.Id, Using = "R1MarketRedirect-close")]
        public IWebElement closePopupButton { get; set; }

        [FindsBy(How = How.Id, Using = "coreui-productplacement-30l7ywa_dg7gmgf0dst3")]
        public IWebElement firstElementResultSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='email-newsletter-dialog']/div[3]/div[1]")]
        public IWebElement closeNewSellerButton { get; set; }

        



        public bool ValidateMenuItems(string expectedItem)
        {
            bool result = false;
            foreach(IWebElement item in menuItems)
            {
                if(item.Text == expectedItem)
                {
                    //Console.WriteLine(item.Text);
                    result = true;
                    break;
                }
                
            }

            return result;
        }

        public void clickOnWindowsMenuOption()
        {
            windowsMenuOption.Click();
        }

        public void printItemPricesSearchResult(ExtentTest test)
        {
            int count = 0;
            foreach (IWebElement item in priceItems)
            {
                test.Log(Status.Info,item.Text);
                Console.WriteLine(item.Text);
                count++;
                if (count > 2)
                    break;
            }
        }

        public void closePopup()
        {
            closePopupButton.Click();
        }

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
            return priceToInt(priceItems.First().Text);
            
        }

        public void clickOnFirstElementSearchResult()
        {
            firstElementResultSearch.Click();
        }
        public void closeNewSellerPopup()
        {
            closeNewSellerButton.Click();
        }
    }
}
