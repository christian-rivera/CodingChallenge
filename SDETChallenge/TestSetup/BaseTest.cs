using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SDETChallenge.TestSetup
{
    [SetUpFixture]
    public class BaseTest
    {
        public IWebDriver driver;
        public ExtentReports extent = null;

        [SetUp]
        public void SetUp()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Reports\\report.html";
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(path);
            extent.AttachReporter(htmlReporter);
            
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            //extent.Flush();
            driver.Quit();
        }

    }
}
