using System.Collections;

namespace BerlinClock.Models
{
    public struct BerlinTimeModel
    {
        public BerlinTimeModel(
            bool secondSet, 
            BitArray fiveHours,
            BitArray hours,
            BitArray fiveMinutes,
            BitArray minutes)
        {
            SecondSet = secondSet;
            FiveHours = fiveHours;
            Hours = hours;
            FiveMinutes = fiveMinutes;
            Minutes = minutes;
        }

        public bool SecondSet { get; }
        public BitArray FiveHours { get; }
        public BitArray Hours { get; }
        public BitArray FiveMinutes { get; }
        public BitArray Minutes { get; }
        public const int MinuteSignalsAlternateCount = 3;
    }
}
