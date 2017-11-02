using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using ValtechAutomationChallenge.SeleniumCommon;

namespace ValtechAutomationChallenge.PageObjects
{
    [Binding]
    public class ContactUsPageObjects : BasePageObject
    {
        public ContactUsPageObjects(IWebDriver driver) : base(driver) { }


        public int CountHowManyOffices()
        {
            var officeCount = Driver.FindElements(By.ClassName("office__description"));
            return officeCount.Count;

        }
    }
}
