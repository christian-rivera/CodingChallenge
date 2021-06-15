// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using SDETChallenge.PageObjects;
using SDETChallenge.TestSetup;
using SDETChallenge.APIHelper;
using SDETChallenge.UIHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using AventStack.ExtentReports;

namespace SDETChallenge
{
    [TestFixture]
    public class Tests : BaseTest
    {
        ArrayList menuItems = new ArrayList() { "Office", "Windows", "Surface", "Xbox", "Deals", "Support" };
        UiHelper uiHelper = new UiHelper();
        UIData uiData = new UIData();
        ApiHelper dataFromApi = new ApiHelper();
        ExtentTest test = null;

        [Test]
        public void MicrosoftPage()
        {
            try
            {
                test = extent.CreateTest("Microsoft Page").Info("Test Started");
                uiData = uiHelper.getUIData();
                test.Log(Status.Info, "Go to https://www.microsoft.com/en-us/");
                driver.Url = ConfigurationManager.AppSettings["microsoft-url"];
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                MicrosoftIndexPO microsoftIndexPO = new MicrosoftIndexPO();
                PageFactory.InitElements(driver, microsoftIndexPO);
                Thread.Sleep(1000);
                test.Log(Status.Info, "Validate all menu items are present (Office - Windows - Surface - Xbox - Deals - Support)");
                foreach (string item in menuItems)
                {
                    Assert.IsTrue(microsoftIndexPO.ValidateMenuItems(item));
                }
                test.Log(Status.Info, "Go to Windows");
                microsoftIndexPO.clickOnWindowsMenuOption();
                Thread.Sleep(1500);
                WindowsPO windowsPO = new WindowsPO();
                PageFactory.InitElements(driver, windowsPO);
                test.Log(Status.Info, "Once in Windows page, click on Windows 10 Menu");
                windowsPO.clickOnWindows10Option();
                Thread.Sleep(500);
                test.Log(Status.Info, "Print all Elements in the dropdown:");
                windowsPO.printWin10MenuItems(test);
                test.Log(Status.Info, "Go to Search next to the shopping cart");
                windowsPO.clickOnSearchButton();
                Thread.Sleep(500);
                test.Log(Status.Info, "Search for Visual Studio");
                windowsPO.setSearchValue(uiData.data.microsoft.MicrosoftProductSearch);
                windowsPO.clickOnSearchButton();
                Thread.Sleep(1000);
                microsoftIndexPO.closePopup();
                test.Log(Status.Info, "Print the price for the 3 first elements listed in Software result list");
                microsoftIndexPO.printItemPricesSearchResult(test);
                test.Log(Status.Info, "Store the price of the first one");
                int firstPrice = microsoftIndexPO.getPrice();
                test.Log(Status.Info, "Click on the first one to go to the details page");
                microsoftIndexPO.clickOnFirstElementSearchResult();
                Thread.Sleep(1500);
                microsoftIndexPO.closeNewSellerPopup();
                Thread.Sleep(1000);
                DetailsPO detailsPO = new DetailsPO();
                PageFactory.InitElements(driver, detailsPO);
                test.Log(Status.Info, "Once in the details page, validate both prices are the same");
                Assert.IsTrue(firstPrice == detailsPO.getPrice());
                test.Log(Status.Info, "Click Add To Cart");
                js.ExecuteScript("window.scrollTo(0, 100)");
                detailsPO.clickOnAddToCartButton();
                Thread.Sleep(1500);
                CartPO cartPO = new CartPO();
                PageFactory.InitElements(driver, cartPO);
                test.Log(Status.Info, "Verify all 3 price amounts are the same");
                Assert.IsTrue(firstPrice == cartPO.getPrice());
                test.Log(Status.Info, "On the # of items dropdown select 20 and validate the Total amount is Unit Price * 20");
                cartPO.selectNumOfItems(uiData.data.microsoft.NoOfItems);
                Thread.Sleep(1500);
                int totalPrice = firstPrice * 20;
                Assert.IsTrue(totalPrice == cartPO.getTotalPrice());
                test.Log(Status.Pass, "Test Passed");
                extent.Flush();
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, e.Message);
                driver.Quit();
            }
            
        }

        [Test]
        public void AmazonPage()
        {
            try
            {
                test = extent.CreateTest("Amazon Page").Info("Test Started");
                ArrayList supportMenuItems = new ArrayList() { "Getting Started", "Wi-Fi and Bluetooth", "Device Software and Hardware", "Troubleshooting" };
                test.Log(Status.Info, "Go to Amazon main page");
                driver.Url = ConfigurationManager.AppSettings["amazon-url"];
                Actions action = new Actions(driver);              
                uiData = uiHelper.getUIData();
                Thread.Sleep(1000);
                AmazonIndexPO amazonIndex = new AmazonIndexPO();
                PageFactory.InitElements(driver, amazonIndex);
                test.Log(Status.Info, "Locate at the upper right corner the button: Hello, Sign In Account & lists and click on it");
                action.MoveToElement(amazonIndex.signInButton).Perform();
                Thread.Sleep(500);
                test.Log(Status.Info, "Click on 'New customer? Start right here'");
                amazonIndex.clickOnStartHereButton();
                AmazonSignUpPO amazonSignUp = new AmazonSignUpPO();
                PageFactory.InitElements(driver, amazonSignUp);
                Thread.Sleep(1000);
                test.Log(Status.Info, "Fill Name field with the response API (dummy.restapi)");
                amazonSignUp.setName(dataFromApi.getUsernameFromApi());
                amazonSignUp.setEmail(uiData.data.amazon.UserEmail);
                test.Log(Status.Info, "Click on Condition of Use link");
                amazonSignUp.clickOnConditionOfUseLink();
                Thread.Sleep(1000);
                test.Log(Status.Info, "Locate the search bar and Search for Echo");
                amazonIndex.searchValue(uiData.data.amazon.AmazonSearchValue);
                Thread.Sleep(1000);
                test.Log(Status.Info, "Locate 'Echo support' options and click on it");
                amazonIndex.clickOnEchoSupportLink();
                Thread.Sleep(1500);
                test.Log(Status.Info, "Following elements should be displayed: Getting Started, Wi-Fi and Bluetooth, Device Software and Hardware, TroubleShooting");
                foreach (string item in supportMenuItems)
                {
                    Assert.IsTrue(amazonIndex.validateSupportMenuItems(item));
                }
                test.Log(Status.Pass,"Test Passed");
                extent.Flush();
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, e.Message);
                extent.Flush();
                driver.Quit();
            }
            
        }
    }
}
