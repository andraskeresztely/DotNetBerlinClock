using BerlinClock.Interfaces;

namespace BerlinClock.Classes
{
    public class TimeConverter : ITimeConverter
    {
        private readonly IBerlinClock berlinClock;
        private readonly IFormatter<string> stringFormatter;

        public TimeConverter()
        {
            berlinClock = new BerlinClock(new TimeParser());
            stringFormatter = new StringFormatter();
        }

        public string ConvertTime(string aTime)
        {
            var berlinTime = berlinClock.GetTime(aTime);
            return stringFormatter.Format(berlinTime);
        }
    }
}
