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
    public class WindowsPO : PageHelper
    {
        [FindsBy(How = How.Id, Using = "c-shellmenu_54")]
        public IWebElement windows10Option { get; set; }
        [FindsBy(How = How.ClassName, Using = "js-subm-uhf-nav-link")]
        public IList<IWebElement> win10menuItems { get; set; }
        [FindsBy(How = How.Id, Using = "search")]
        public IWebElement searchButton { get; set; }
        [FindsBy(How = How.Id, Using = "cli_shellHeaderSearchInput")]
        public IWebElement inputSearch { get; set; }

        

        public void clickOnWindows10Option()
        {
            windows10Option.Click();
        }
        public void printWin10MenuItems(ExtentTest test)
        {
            foreach(IWebElement item in win10menuItems)
            {
                if(item.Text != String.Empty)
                {
                    test.Log(Status.Info, item.Text);
                    Console.WriteLine(item.Text);
                }
            }
        }
        public override void clickOnSearchButton()
        {
            searchButton.Click();
        }
        public void setSearchValue(string value)
        {
            inputSearch.SendKeys(value);
        }
    }
}
