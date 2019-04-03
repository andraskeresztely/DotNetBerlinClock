using BerlinClock.Interfaces;
using BerlinClock.Models;

namespace BerlinClock.Classes
{
    internal class TimeParser : ITimeParser
    {
        public const char TimeSeparator = ':';
        private const int TimePartsRequired = 3;
        private const int MinValidHours = 0;
        private const int MaxValidHours = 24;
        private const int MinValidMinutes = 0;
        private const int MaxValidMinutes = 59;
        private const int MinValidSeconds = 0;
        private const int MaxValidSeconds = 59;

        public bool TryParse(string inputTime, out TimeModel timeModel)
        {
            timeModel = new TimeModel();

            if (string.IsNullOrEmpty(inputTime))
            {
                return false;
            }

            var inputTimeParts = inputTime.Split(TimeSeparator);
            if (inputTimeParts.Length != TimePartsRequired)
            {
                return false;
            }

            var hourValid = Parse(inputTimeParts[0], out var hours, MinValidHours, MaxValidHours);
            var minuteValid = Parse(inputTimeParts[1], out var minutes, MinValidMinutes, MaxValidMinutes);
            var secondValid = Parse(inputTimeParts[2], out var seconds, MinValidSeconds, MaxValidSeconds);

            if (!hourValid || !minuteValid || !secondValid)
            {
                return false;
            }

            if (hours == 24 && (minutes > 0 || seconds > 0))
            {
                return false;
            }

            timeModel = new TimeModel(hours, minutes, seconds);
            return true;
        }

        private static bool Parse(string value, out int parsedValue, int minValue, int maxValue)
        {
            var valid = Parse(value, out parsedValue);

            return valid && parsedValue >= minValue && parsedValue <= maxValue;
        }

        private static bool Parse(string value, out int parsedValue)
        {
            return int.TryParse(value, out parsedValue);
        }
    }
}
