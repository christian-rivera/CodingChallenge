using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDETChallenge.PageObjects
{
    class AmazonIndexPO : PageHelper
    {
        [FindsBy(How = How.ClassName, Using = "nav-line-1-container")]
        public IWebElement signInButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#nav-flyout-ya-newCust > a")]
        public IWebElement startHereButton { get; set; }

        [FindsBy(How = How.Id, Using = "helpsearch")]

        public IWebElement searchInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "a-icon-search")]

        public IWebElement searchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Echo Support']")]
        public IWebElement echoSupportLink { get; set; }

        [FindsBy(How = How.ClassName, Using = "a-accordion-row")]
        public IList<IWebElement> supportMenuItems { get; set; }

        public void clickOnStartHereButton()
        {
            startHereButton.Click();
        }

        public override void clickOnSearchButton()
        {
            searchButton.Click();
        }

        public void searchValue(string value)
        {
            searchInput.SendKeys(value);
            searchInput.SendKeys(Keys.Return);
        }

        public void clickOnEchoSupportLink()
        {
            echoSupportLink.Click();
        }

        public bool validateSupportMenuItems(string expectedItem)
        {
            bool result = false;
            foreach (IWebElement item in supportMenuItems)
            {
                if (item.Text == expectedItem)
                {
                    result = true;
                    break;
                }

            }

            return result;
        }
    }
}
