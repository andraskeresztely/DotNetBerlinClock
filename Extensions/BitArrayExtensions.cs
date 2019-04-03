using System.Collections;

namespace BerlinClock.Extensions
{
    public static class BitArrayExtensions
    {
        public static BitArray SetBits(this BitArray bitArray, int value)
        {
            for (var i = 0; i < value; i++)
            {
                bitArray.Set(i, true);
            }

            return bitArray;
        }
    }
}
