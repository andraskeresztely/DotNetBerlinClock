using BerlinClock.Models;

namespace BerlinClock.Interfaces
{
    internal interface IFormatter<out T>
    {
        T Format(BerlinTimeModel timeModel);
    }
}
