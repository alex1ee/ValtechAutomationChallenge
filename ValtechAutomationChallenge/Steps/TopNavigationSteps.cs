using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using ValtechAutomationChallenge.PageObjects;

namespace ValtechAutomationChallenge.Steps
{
    [Binding]
    public sealed class TopNavigationSteps
    {
        private TopNavigationPageObject _navigationPageObject;

        public TopNavigationSteps()
        {
            _navigationPageObject = new TopNavigationPageObject(StepsContext.Driver);
        }

        [When(@"I select the (.*) link from the top navigation")]
        public void WhenISelectTheLinkFromTheTopNavigation(string link)
        {
            _navigationPageObject.SelectLink(link);
        }

        [When(@"I select the Contact Us Icon")]
        public void WhenISelectTheContactUsIcon()
        {
            _navigationPageObject.NavigateToContactUsPage();
        }


    }
}
