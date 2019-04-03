using BerlinClock.Models;

namespace BerlinClock.Interfaces
{
    internal interface IBerlinClock
    {
        BerlinTimeModel GetTime(string inputTime);
    }
}
