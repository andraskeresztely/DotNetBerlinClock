using BerlinClock.Classes;
using BerlinClock.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.Tests.Classes
{
    [TestClass]
    public class TimeParserTests
    {
        private TimeParser timeParser;
        private TimeModel timeModel;
        private const char S = TimeParser.TimeSeparator;

        [TestInitialize]
        public void Initialise()
        {
            timeParser = new TimeParser();
        }

        [TestMethod]
        public void TryParse_WhenNullString_ThenReturnsFalse()
        {
            var result = timeParser.TryParse(null, out timeModel);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_WhenEmptyString_ThenReturnsFalse()
        {
           var result = timeParser.TryParse(string.Empty, out timeModel);
           Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_WhenStringWithoutSeparator_ThenReturnsFalse()
        {
            var result = timeParser.TryParse("1234", out timeModel);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_WhenStringWithTwoParts_ThenReturnsFalse()
        {
            var result = timeParser.TryParse($"12{S}34", out timeModel);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_WhenStringWithFourParts_ThenReturnsFalse()
        {
            var result = timeParser.TryParse($"12{S}34{S}56{S}00", out timeModel);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_WhenStringWithThreePartsAndWrongSeparator_ThenReturnsFalse()
        {
            var result = timeParser.TryParse("12@34@56", out timeModel);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_WhenStringWithThreePartsAndAllInvalid_ThenReturnsFalse()
        {
            var result = timeParser.TryParse($"AB{S}CD{S}EF", out timeModel);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_WhenStringWithThreePartsAndHourInvalid_ThenReturnsFalse()
        {
            var result = timeParser.TryParse($"25{S}34{S}56", out timeModel);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_WhenStringWithThreePartsAndMinuteInvalid_ThenReturnsFalse()
        {
            var result = timeParser.TryParse($"12{S}67{S}56", out timeModel);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_WhenStringWithThreePartsAndSecondInvalid_ThenReturnsFalse()
        {
            var result = timeParser.TryParse("12{S}34{S}78", out timeModel);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_WhenStringWithThreePartsAndAllValid_ThenReturnsTrue()
        {
            var result = timeParser.TryParse($"12{S}34{S}56", out timeModel);
            Assert.IsTrue(result);
            Assert.AreEqual(12, timeModel.Hours);
            Assert.AreEqual(34, timeModel.Minutes);
            Assert.AreEqual(56, timeModel.Seconds);
        }

        [TestMethod]
        public void TryParse_WhenStringWithOneMinuteBeforeMidnight_ThenReturnsTrue()
        {
            var result = timeParser.TryParse($"23{S}59{S}59", out timeModel);
            Assert.IsTrue(result);
            Assert.AreEqual(23, timeModel.Hours);
            Assert.AreEqual(59, timeModel.Minutes);
            Assert.AreEqual(59, timeModel.Seconds);
        }

        [TestMethod]
        public void TryParse_WhenStringWithMidnight0Hours_ThenReturnsTrue()
        {
            var result = timeParser.TryParse($"00{S}00{S}00", out timeModel);
            Assert.IsTrue(result);
            Assert.AreEqual(0, timeModel.Hours);
            Assert.AreEqual(0, timeModel.Minutes);
            Assert.AreEqual(0, timeModel.Seconds);
        }

        [TestMethod]
        public void TryParse_WhenStringWithMidnight24Hours_ThenReturnsTrue()
        {
            var result = timeParser.TryParse($"24{S}00{S}00", out timeModel);
            Assert.IsTrue(result);
            Assert.AreEqual(24, timeModel.Hours);
            Assert.AreEqual(0, timeModel.Minutes);
            Assert.AreEqual(0, timeModel.Seconds);
        }

        [TestMethod]
        public void TryParse_WhenStringWithMidnight24HoursAndOneMinute_ThenReturnsFalse()
        {
            var result = timeParser.TryParse($"24{S}01{S}00", out timeModel);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_WhenStringWithMidnight24HoursAndOneSecond_ThenReturnsFalse()
        {
            var result = timeParser.TryParse($"24{S}00{S}01", out timeModel);
            Assert.IsFalse(result);
        }
    }
}
