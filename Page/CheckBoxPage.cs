using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotest.Page
{
    public class CheckboxDemoPage : BasePage
    {
        private const string url = "http://demo.seleniumeasy.com/basic-checkbox-demo.html";
        private IWebElement firstCheckbox => Driver.FindElement(By.Id("isAgeSelected"));
        private IReadOnlyCollection<IWebElement> checkboxes => Driver.FindElements(By.CssSelector(".cb1-element"));
        private IWebElement button => Driver.FindElement(By.Id("check1"));
        private IWebElement resultElement => Driver.FindElement(By.Id("txtAge"));

        public CheckboxDemoPage(IWebDriver webDriver) : base(webDriver) { }

        public void NavigateToPage()
        {
            if (!Driver.Url.Equals(url))
            {
                Driver.Url = url;
            }

        }

        public void ClickOnFirstCheckbox()
        {
            ClickOnCheckbox(true);
        }

        public void ClickOnAllCheckboxes()
        {
            CheckAllCheckboxes(checkboxes);
        }

        public void VerifyResult()
        {
            Assert.IsTrue("Success - Check box is checked".Equals(resultElement.Text), $"Text is not the same, actual text is {resultElement.Text}");
        }

        public void VerifyButtonText()
        {
            Assert.IsTrue(IsButtonWithValue(button, "Uncheck All"), "Text is not correct");
        }

        public void ClickOnButton()
        {
            ClickOnCheckbox(false);
            if (!IsButtonWithValue(button, "Uncheck All"))
            {
                CheckAllCheckboxes(checkboxes);
            }
            button.Click();
        }

        public void VerifyAllCheckboxesUnchecked()
        {
            foreach (IWebElement checkbox in checkboxes)
            {
                Assert.IsFalse(checkbox.Selected);
            }
            Assert.IsTrue(IsButtonWithValue(button, "Check All"), "Text is not correct");
        }

        private void ClickOnCheckbox(bool shouldBeCheck)
        {
            if (firstCheckbox.Selected != shouldBeCheck)
            {
                firstCheckbox.Click();
            }
        }

        private bool IsButtonWithValue(IWebElement button, string value)
        {
            return value.Equals(button.GetAttribute("value"));
        }

        private void CheckAllCheckboxes(IReadOnlyCollection<IWebElement> checkboxes)
        {
            ClickOnCheckbox(false);
            foreach (IWebElement checkbox in checkboxes)
            {
                if (!checkbox.Selected)
                {
                    checkbox.Click();
                }
            }
        }

    }

}
