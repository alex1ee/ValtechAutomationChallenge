using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using ValtechAutomationChallenge.SeleniumCommon;

namespace ValtechAutomationChallenge.PageObjects
{
    [Binding]
    public class WebBasePageObject : BasePageObject
    {
        public WebBasePageObject(IWebDriver driver) : base(driver) { }


        public string GetH1TagValue()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.Until(d => d.FindElement(By.TagName("H1")).Displayed.Equals(true));

            return Driver.FindElement(By.TagName("H1")).Text;
        }

    }
}
