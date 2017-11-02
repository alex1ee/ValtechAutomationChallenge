using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using ValtechAutomationChallenge.PageObjects;

namespace ValtechAutomationChallenge.Steps
{
    [Binding]
    public sealed class ContactUsSteps
    {
        private ContactUsPageObjects _contactUsPageObjects;

        public ContactUsSteps()
        {
            _contactUsPageObjects = new ContactUsPageObjects(StepsContext.Driver);
        }

        [Then(@"I will display how many offices there are")]
        public void ThenIWillDisplayHowManyOfficesThereAre()
        {
            var offices = _contactUsPageObjects.CountHowManyOffices();
            Console.WriteLine("Total Offices: {0}", offices);
        }
    }
}
