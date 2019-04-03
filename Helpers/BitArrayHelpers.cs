using System.Collections;

namespace BerlinClock.Helpers
{
    public static class BitArrayHelpers
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
