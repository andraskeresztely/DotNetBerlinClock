using System;
using System.Collections;
using BerlinClock.Classes;
using BerlinClock.Extensions;
using BerlinClock.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.Tests.Classes
{
    [TestClass]
    public class StringFormatterTests
    {
        private StringFormatter stringFormatter;
        private const char O = StringFormatter.NoSignal;
        private const char R = StringFormatter.RedSignal;
        private const char Y = StringFormatter.YellowSignal;
        private readonly string n = Environment.NewLine;

        [TestInitialize]
        public void Initialise()
        {
            stringFormatter = new StringFormatter();
        }

        [TestMethod]
        public void Format_When000000_ThenReturnsCorrectResult()
        {
            var timeModel = new BerlinTimeModel(
                true,
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow),
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow),
                new BitArray(BerlinClock.Classes.BerlinClock.MinuteSignalsPerRow),
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow));

            Assert.AreEqual(
                stringFormatter.Format(timeModel),
                $"{Y}{n}{O}{O}{O}{O}{n}{O}{O}{O}{O}{n}{O}{O}{O}{O}{O}{O}{O}{O}{O}{O}{O}{n}{O}{O}{O}{O}");
        }

        [TestMethod]
        public void Format_When024714_ThenReturnsCorrectResult()
        {
            var timeModel = new BerlinTimeModel(
                true,
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow),
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(2),
                new BitArray(BerlinClock.Classes.BerlinClock.MinuteSignalsPerRow).SetBits(9),
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(2));

            Assert.AreEqual(
                stringFormatter.Format(timeModel),
                $"{Y}{n}{O}{O}{O}{O}{n}{R}{R}{O}{O}{n}{Y}{Y}{R}{Y}{Y}{R}{Y}{Y}{R}{O}{O}{n}{Y}{Y}{O}{O}");
        }

        [TestMethod]
        public void Format_When071351_ThenReturnsCorrectResult()
        {
            var timeModel = new BerlinTimeModel(
                false,
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(1),
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(2),
                new BitArray(BerlinClock.Classes.BerlinClock.MinuteSignalsPerRow).SetBits(2),
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(3));

            Assert.AreEqual(
                stringFormatter.Format(timeModel),
                $"{O}{n}{R}{O}{O}{O}{n}{R}{R}{O}{O}{n}{Y}{Y}{O}{O}{O}{O}{O}{O}{O}{O}{O}{n}{Y}{Y}{Y}{O}");
        }

        [TestMethod]
        public void Format_When120000_ThenReturnsCorrectResult()
        {
            var timeModel = new BerlinTimeModel(
                true,
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(2),
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(2),
                new BitArray(BerlinClock.Classes.BerlinClock.MinuteSignalsPerRow),
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow));

            Assert.AreEqual(
                stringFormatter.Format(timeModel),
                $"{Y}{n}{R}{R}{O}{O}{n}{R}{R}{O}{O}{n}{O}{O}{O}{O}{O}{O}{O}{O}{O}{O}{O}{n}{O}{O}{O}{O}");
        }

        [TestMethod]
        public void Format_When131701_ThenReturnsCorrectResult()
        {
            var timeModel = new BerlinTimeModel(
                false,
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(2),
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(3),
                new BitArray(BerlinClock.Classes.BerlinClock.MinuteSignalsPerRow).SetBits(3),
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(2));

            Assert.AreEqual(
                stringFormatter.Format(timeModel),
                $"{O}{n}{R}{R}{O}{O}{n}{R}{R}{R}{O}{n}{Y}{Y}{R}{O}{O}{O}{O}{O}{O}{O}{O}{n}{Y}{Y}{O}{O}");
        }

        [TestMethod]
        public void Format_When183221_ThenReturnsCorrectResult()
        {
            var timeModel = new BerlinTimeModel(
                false,
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(3),
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(3),
                new BitArray(BerlinClock.Classes.BerlinClock.MinuteSignalsPerRow).SetBits(6),
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(2));

            Assert.AreEqual(
                stringFormatter.Format(timeModel),
                $"{O}{n}{R}{R}{R}{O}{n}{R}{R}{R}{O}{n}{Y}{Y}{R}{Y}{Y}{R}{O}{O}{O}{O}{O}{n}{Y}{Y}{O}{O}");
        }

        [TestMethod]
        public void Format_When212911_ThenReturnsCorrectResult()
        {
            var timeModel = new BerlinTimeModel(
                false,
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(4),
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(1),
                new BitArray(BerlinClock.Classes.BerlinClock.MinuteSignalsPerRow).SetBits(5),
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(4));

            Assert.AreEqual(
                stringFormatter.Format(timeModel),
                $"{O}{n}{R}{R}{R}{R}{n}{R}{O}{O}{O}{n}{Y}{Y}{R}{Y}{Y}{O}{O}{O}{O}{O}{O}{n}{Y}{Y}{Y}{Y}");
        }

        [TestMethod]
        public void Format_When235959_ThenReturnsCorrectResult()
        {
            var timeModel = new BerlinTimeModel(
                false,
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(4),
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(3),
                new BitArray(BerlinClock.Classes.BerlinClock.MinuteSignalsPerRow).SetBits(11),
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(4));

            Assert.AreEqual(
                stringFormatter.Format(timeModel),
                $"{O}{n}{R}{R}{R}{R}{n}{R}{R}{R}{O}{n}{Y}{Y}{R}{Y}{Y}{R}{Y}{Y}{R}{Y}{Y}{n}{Y}{Y}{Y}{Y}");
        }

        [TestMethod]
        public void Format_When240000_ThenReturnsCorrectResult()
        {
            var timeModel = new BerlinTimeModel(
                true,
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(4),
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow).SetBits(4),
                new BitArray(BerlinClock.Classes.BerlinClock.MinuteSignalsPerRow),
                new BitArray(BerlinClock.Classes.BerlinClock.DefaultSignalsPerRow));

            Assert.AreEqual(
                stringFormatter.Format(timeModel),
                $"{Y}{n}{R}{R}{R}{R}{n}{R}{R}{R}{R}{n}{O}{O}{O}{O}{O}{O}{O}{O}{O}{O}{O}{n}{O}{O}{O}{O}");
        }
    }
}
