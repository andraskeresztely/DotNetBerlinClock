using System;
using BerlinClock.Interfaces;
using BerlinClock.Models;
using System.Collections;
using BerlinClock.Extensions;
using BerlinClock.Resources;

namespace BerlinClock.Classes
{
    internal class BerlinClock : IClock<BerlinTimeModel>
    {
        private readonly ITimeParser timeParser;
        public const int DefaultSignalsPerRow = 4;
        public const int MinuteSignalsPerRow = 11;

        public BerlinClock(ITimeParser timeParser)
        {
            this.timeParser = timeParser;
        }

        public BerlinTimeModel GetTime(string inputTime)
        {
            if (!timeParser.TryParse(inputTime, out var timeModel))
            {
                throw new ArgumentException(BerlinClockResource.InvalidArgumentError);
            }

            var secondSet = timeModel.Seconds % 2 == 0;
            var fiveHours = new BitArray(DefaultSignalsPerRow).SetBits(timeModel.Hours / 5);
            var hours = new BitArray(DefaultSignalsPerRow).SetBits(timeModel.Hours % 5);
            var fiveMinutes = new BitArray(MinuteSignalsPerRow).SetBits(timeModel.Minutes / 5);
            var minutes = new BitArray(DefaultSignalsPerRow).SetBits(timeModel.Minutes % 5);

            var berlinTimeModel = new BerlinTimeModel(
                secondSet, 
                fiveHours, 
                hours, 
                fiveMinutes, 
                minutes);

            return berlinTimeModel;
        }
    }
}
