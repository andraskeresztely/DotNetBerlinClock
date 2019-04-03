using BerlinClock.Models;

namespace BerlinClock.Interfaces
{
    internal interface ITimeParser
    {
        bool TryParse(string inputTime, out TimeModel timeModel);
    }
}
