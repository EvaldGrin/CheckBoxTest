using Autotest.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotest.Test
{
    public class CheckboxTest : BaseTest
    {
        [Test]
        public static void Test1OneCheckbox()
        {
            checkboxPage.NavigateToPage();
            checkboxPage.ClickOnFirstCheckbox();
            checkboxPage.VerifyResult();
        }

        [Test]
        public static void Test2ManyCheckboxes()
        {
            checkboxPage.ClickOnAllCheckboxes();
            checkboxPage.VerifyButtonText();
        }

        [Test]
        public static void Test3ManyCheckboxes()
        {
            checkboxPage.ClickOnButton();
            checkboxPage.VerifyAllCheckboxesUnchecked();
        }
    }
}
