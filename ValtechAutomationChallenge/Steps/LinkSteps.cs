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
    public sealed class LinkSteps
    {
        private WebBasePageObject _webBasePageObject;

        public LinkSteps()
        {
            _webBasePageObject = new WebBasePageObject(StepsContext.Driver);
        }

        [Then(@"the H1 tag is displaying (.*)")]
        public void ThenTheHTagIsDisplayingCases(string link)
        {
            var value = _webBasePageObject.GetH1TagValue();
            Assert.AreEqual(link, value, "H1 Value did not match for page");
        }

    }
}
