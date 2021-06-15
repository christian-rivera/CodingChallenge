using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDETChallenge.PageObjects
{
    class AmazonSignUpPO
    {
        [FindsBy(How = How.Id, Using = "ap_customer_name")]
        public IWebElement inputName { get; set; }

        [FindsBy(How = How.Id, Using = "ap_email")]
        public IWebElement inputEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='legalTextRow']/a[1]")]
        public IWebElement ConditionOfUseLink { get; set; }

        public void setName(string name)
        {
            inputName.SendKeys(name);
        }

        public void setEmail(string email)
        {
            inputEmail.SendKeys(email);
        }

        public void clickOnConditionOfUseLink()
        {
            ConditionOfUseLink.Click();
        }
    }
}
