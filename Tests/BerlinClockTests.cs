using System;
using System.Linq;
using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.Tests
{
    [TestClass]
    public class BerlinClockTests
    {
        private Classes.BerlinClock berlinClock;

        [TestInitialize]
        public void Initialise()
        {
            berlinClock = new Classes.BerlinClock(new TimeParser());
        }
        
        [TestMethod]
        public void GetTime_When000000_ThenReturnsCorrectResult()
        {
            var result = berlinClock.GetTime("00:00:00");

            Assert.IsTrue(result.SecondSet);
            Assert.IsTrue(result.FiveHours.Cast<bool>().All(r => !r));
            Assert.IsTrue(result.Hours.Cast<bool>().All(r => !r));
            Assert.IsTrue(result.FiveMinutes.Cast<bool>().All(r => !r));
            Assert.IsTrue(result.Minutes.Cast<bool>().All(r => !r));
        }

        [TestMethod]
        public void GetTime_When024714_ThenReturnsCorrectResult()
        {
            var result = berlinClock.GetTime("02:47:14");

            Assert.IsTrue(result.SecondSet);
            Assert.IsTrue(result.FiveHours.Cast<bool>().All(r => !r));
            Assert.IsTrue(result.Hours.Cast<bool>().Take(2).All(r => r));
            Assert.IsTrue(result.Hours.Cast<bool>().Skip(2).All(r => !r));
            Assert.IsTrue(result.FiveMinutes.Cast<bool>().Take(9).All(r => r));
            Assert.IsTrue(result.FiveMinutes.Cast<bool>().Skip(9).All(r => !r));
            Assert.IsTrue(result.Minutes.Cast<bool>().Take(2).All(r => r));
            Assert.IsTrue(result.Minutes.Cast<bool>().Skip(2).All(r => !r));
        }

        [TestMethod]
        public void GetTime_When071351_ThenReturnsCorrectResult()
        {
            var result = berlinClock.GetTime("07:13:51");

            Assert.IsFalse(result.SecondSet);
            Assert.IsTrue(result.FiveHours.Cast<bool>().Take(1).All(r => r));
            Assert.IsTrue(result.FiveHours.Cast<bool>().Skip(1).All(r => !r));
            Assert.IsTrue(result.Hours.Cast<bool>().Take(2).All(r => r));
            Assert.IsTrue(result.Hours.Cast<bool>().Skip(2).All(r => !r));
            Assert.IsTrue(result.FiveMinutes.Cast<bool>().Take(2).All(r => r));
            Assert.IsTrue(result.FiveMinutes.Cast<bool>().Skip(2).All(r => !r));
            Assert.IsTrue(result.Minutes.Cast<bool>().Take(3).All(r => r));
            Assert.IsTrue(result.Minutes.Cast<bool>().Skip(3).All(r => !r));
        }

        [TestMethod]
        public void GetTime_When120000_ThenReturnsCorrectResult()
        {
            var result = berlinClock.GetTime("12:00:00");

            Assert.IsTrue(result.SecondSet);
            Assert.IsTrue(result.FiveHours.Cast<bool>().Take(2).All(r => r));
            Assert.IsTrue(result.FiveHours.Cast<bool>().Skip(2).All(r => !r));
            Assert.IsTrue(result.Hours.Cast<bool>().Take(2).All(r => r));
            Assert.IsTrue(result.Hours.Cast<bool>().Skip(2).All(r => !r));
            Assert.IsTrue(result.FiveMinutes.Cast<bool>().All(r => !r));
            Assert.IsTrue(result.Minutes.Cast<bool>().All(r => !r));
        }

        [TestMethod]
        public void GetTime_When131701_ThenReturnsCorrectResult()
        {
            var result = berlinClock.GetTime("13:17:01");

            Assert.IsFalse(result.SecondSet);
            Assert.IsTrue(result.FiveHours.Cast<bool>().Take(2).All(r => r));
            Assert.IsTrue(result.FiveHours.Cast<bool>().Skip(2).All(r => !r));
            Assert.IsTrue(result.Hours.Cast<bool>().Take(3).All(r => r));
            Assert.IsTrue(result.Hours.Cast<bool>().Skip(3).All(r => !r));
            Assert.IsTrue(result.FiveMinutes.Cast<bool>().Take(3).All(r => r));
            Assert.IsTrue(result.FiveMinutes.Cast<bool>().Skip(3).All(r => !r));
            Assert.IsTrue(result.Minutes.Cast<bool>().Take(2).All(r => r));
            Assert.IsTrue(result.Minutes.Cast<bool>().Skip(2).All(r => !r));
        }

        [TestMethod]
        public void GetTime_When183221_ThenReturnsCorrectResult()
        {
            var result = berlinClock.GetTime("18:32:21");

            Assert.IsFalse(result.SecondSet);
            Assert.IsTrue(result.FiveHours.Cast<bool>().Take(3).All(r => r));
            Assert.IsTrue(result.FiveHours.Cast<bool>().Skip(3).All(r => !r));
            Assert.IsTrue(result.Hours.Cast<bool>().Take(3).All(r => r));
            Assert.IsTrue(result.Hours.Cast<bool>().Skip(3).All(r => !r));
            Assert.IsTrue(result.FiveMinutes.Cast<bool>().Take(6).All(r => r));
            Assert.IsTrue(result.FiveMinutes.Cast<bool>().Skip(6).All(r => !r));
            Assert.IsTrue(result.Minutes.Cast<bool>().Take(2).All(r => r));
            Assert.IsTrue(result.Minutes.Cast<bool>().Skip(2).All(r => !r));
        }

        [TestMethod]
        public void GetTime_When212911_ThenReturnsCorrectResult()
        {
            var result = berlinClock.GetTime("21:29:11");

            Assert.IsFalse(result.SecondSet);
            Assert.IsTrue(result.FiveHours.Cast<bool>().All(r => r));
            Assert.IsTrue(result.Hours.Cast<bool>().Take(1).All(r => r));
            Assert.IsTrue(result.Hours.Cast<bool>().Skip(1).All(r => !r));
            Assert.IsTrue(result.FiveMinutes.Cast<bool>().Take(5).All(r => r));
            Assert.IsTrue(result.FiveMinutes.Cast<bool>().Skip(5).All(r => !r));
            Assert.IsTrue(result.Minutes.Cast<bool>().All(r => r));
        }

        [TestMethod]
        public void GetTime_When235959_ThenReturnsCorrectResult()
        {
            var result = berlinClock.GetTime("23:59:59");

            Assert.IsFalse(result.SecondSet);
            Assert.IsTrue(result.FiveHours.Cast<bool>().All(r => r));
            Assert.IsTrue(result.Hours.Cast<bool>().Take(3).All(r => r));
            Assert.IsTrue(result.Hours.Cast<bool>().Skip(3).All(r => !r));
            Assert.IsTrue(result.FiveMinutes.Cast<bool>().All(r => r));
            Assert.IsTrue(result.Minutes.Cast<bool>().All(r => r));
        }

        [TestMethod]
        public void GetTime_When240000_ThenReturnsCorrectResult()
        {
            var result = berlinClock.GetTime("24:00:00");

            Assert.IsTrue(result.SecondSet);
            Assert.IsTrue(result.FiveHours.Cast<bool>().All(r => r));
            Assert.IsTrue(result.Hours.Cast<bool>().All(r => r));
            Assert.IsTrue(result.FiveMinutes.Cast<bool>().All(r => !r));
            Assert.IsTrue(result.Minutes.Cast<bool>().All(r => !r));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetTime_When250000_ThenExceptionThrown()
        {
            berlinClock.GetTime("25:00:00");
        }
    }
}
