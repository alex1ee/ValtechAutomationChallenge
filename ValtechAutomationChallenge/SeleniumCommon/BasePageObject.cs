using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace ValtechAutomationChallenge.SeleniumCommon
{
    public class BasePageObject
    {
        protected IWebDriver Driver { get; private set; }
        protected WebDriverWait WebDriverWait { get; private set; }

        public string GetPageSource()
        {
            return Driver.PageSource;
        }

        public void Refresh()
        {
            Driver.Navigate().Refresh();
        }

        public void WaitForPageToLoad()
        {
            Console.WriteLine("Waiting...");
        }

        protected BasePageObject(IWebDriver driver)
        {
            Driver = driver;
            WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            PageFactory.InitElements(Driver, this);
        }
    }
}
