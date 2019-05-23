namespace BerlinClock.Interfaces
{
    internal interface IClock<out T>
    {
        T GetTime(string inputTime);
    }
}
