using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Plugins;
using ValtechAutomationChallenge.SeleniumCommon;

namespace ValtechAutomationChallenge.PageObjects
{
    [Binding]
    public class HomePageObject : BasePageObject
    {

        public HomePageObject(IWebDriver driver) : base(driver) { }



        public void LoadValtechHomePage()
        {
            var homePage = ConfigurationManager.AppSettings["ValtechHomePageAddress"];
            Driver.Navigate().GoToUrl(homePage);

            if (Driver.Url.Contains("service"))
                Driver.Navigate().GoToUrl(homePage);
        }

        public bool IsLatestNewsSectionDisplayed()
        {
            var latestNewsElement = Driver.FindElements(By.ClassName("block-header__heading"));

            var count = latestNewsElement.Count(e => e.Text.ToLower() == "latest news");

            if (count == 1)
                return true;

            return false;
        }
    }
}
