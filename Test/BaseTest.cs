using Autotest.Drivers;
using Autotest.Page;
using Autotest.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotest.Test
{    
    public class BaseTest
    {
        //Klases objektai
        protected static IWebDriver driver; 
        protected static KilobaitasHomePage _kilobaitasHomePage;
        protected static KilobaitasSearchResultPage _kilobaitasSearchResultPage;
        protected static KilobaitasAddToCartPage _kilobaitasAddToCartPage;
        protected static KilobaitasLoginPage _kilobaitasLoginPage;
        protected static KilobaitasAddressPage _kilobaitasAdressPage;
        protected static DropdownPage drodownPage;
        protected static SumCalculationPage sumCalculationPage;
        protected static CheckboxDemoPage checkboxPage;
        public static SebPage sebPage;
        protected static SenukaiPage _senukaiPage;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            _kilobaitasHomePage = new KilobaitasHomePage(driver);
            _kilobaitasSearchResultPage = new KilobaitasSearchResultPage(driver);
            _kilobaitasAddToCartPage = new KilobaitasAddToCartPage(driver);
            _kilobaitasLoginPage = new KilobaitasLoginPage(driver);
            _kilobaitasAdressPage = new KilobaitasAddressPage(driver);
            drodownPage = new DropdownPage(driver);
            sumCalculationPage = new SumCalculationPage(driver);
            checkboxPage = new CheckboxDemoPage(driver);
            sebPage = new SebPage(driver);


        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreeshot(driver);
            }
        }


        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }



    }


}
