﻿using BerlinClock.Classes;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BerlinClock.Interfaces;

namespace BerlinClock.BDD
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private ITimeConverter berlinClock = new TimeConverter();
        private string theTime;

        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(berlinClock.ConvertTime(theTime), theExpectedBerlinClockOutput);
        }

    }
}
