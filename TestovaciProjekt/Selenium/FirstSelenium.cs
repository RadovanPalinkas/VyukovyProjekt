using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace Selenium
{
    [TestClass]
    class FirstSelenium
    {

       
            public IWebDriver driverIE;
            public IWebDriver driverChrome;



            [TestInitialize]
            public void CheckMethod()
            {




            }
            [TestMethod]
            public void TestIE()
            {

                driverIE = new InternetExplorerDriver();
                driverIE.Navigate().GoToUrl("https://www.google.cz");
                driverIE.Manage().Window.Maximize();
                driverIE.Close();
            }
            [TestMethod]
            public void TestChrome()
            {

                driverChrome = new ChromeDriver();
                driverChrome.Navigate().GoToUrl("https://www.google.cz");
                driverChrome.Manage().Window.Maximize();
                driverChrome.Close();
            }



        
    }
}
