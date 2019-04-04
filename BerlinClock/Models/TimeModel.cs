namespace BerlinClock.Models
{
    internal struct TimeModel
    {
        public TimeModel(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public int Hours { get; }
        public int Minutes { get; }
        public int Seconds { get; }
    }
}
