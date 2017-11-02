using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;
using ValtechAutomationChallenge.PageObjects;

namespace ValtechAutomationChallenge.Steps
{
    [Binding]
    public sealed class HomeSteps
    {
        private HomePageObject _homePageObject;

        public HomeSteps()
        {
            _homePageObject = new HomePageObject(StepsContext.Driver);

        }
        [Given(@"I have navigated to the Valtech Homepage")]
        public void GivenIHaveNavigatedToTheValtechHomepage()
        {
            _homePageObject.LoadValtechHomePage();
        }

        [Then(@"the Latest News section is displayed")]
        public void ThenTheLatestNewsSectionIsDisplayed()
        {
            var latestNewsDisplayed = _homePageObject.IsLatestNewsSectionDisplayed();
            Assert.True(latestNewsDisplayed, "Could not find Latest News section on homepage");
        }

    }
}
