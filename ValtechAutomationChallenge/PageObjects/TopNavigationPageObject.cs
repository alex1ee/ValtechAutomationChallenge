using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ValtechAutomationChallenge.SeleniumCommon;

namespace ValtechAutomationChallenge.PageObjects
{
    public class TopNavigationPageObject : BasePageObject
    {
        public TopNavigationPageObject(IWebDriver driver) : base(driver) { }

        public void SelectLink(string linkText)
        {


            var link = Driver.FindElement(By.PartialLinkText(linkText.ToLower()));

            link.Click();
        }

        public void NavigateToContactUsPage()
        {
            Driver.Navigate().GoToUrl("https://www.valtech.com/contact-us/");
        }
    }
}
