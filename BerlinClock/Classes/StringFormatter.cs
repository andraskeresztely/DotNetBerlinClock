using BerlinClock.Interfaces;
using BerlinClock.Models;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BerlinClock.Classes
{
    internal class StringFormatter : IFormatter<string>
    {
        public const char NoSignal = 'O';
        public const char RedSignal = 'R';
        public const char YellowSignal = 'Y';
       
        public string Format(BerlinTimeModel timeModel)
        {
            var builder = new StringBuilder();

            builder.Append(timeModel.SecondSet ? YellowSignal : NoSignal).AppendLine();
            builder.Append(GetRowOfSignals(timeModel.FiveHours, RedSignal)).AppendLine();
            builder.Append(GetRowOfSignals(timeModel.Hours, RedSignal)).AppendLine();
            builder.Append(GetRowOfSignals(timeModel.FiveMinutes, YellowSignal,
                BerlinTimeModel.MinuteSignalsAlternateCount, RedSignal)).AppendLine();
            builder.Append(GetRowOfSignals(timeModel.Minutes, YellowSignal));

            return builder.ToString();
        }

        private static char[] GetRowOfSignals(
            BitArray signalBits, 
            char signal, 
            int? alternateCount = null, 
            char? alternateSignal = null)
        {
            var rowOfSignals = new List<char>();

            for (var i = 0; i < signalBits.Count; i++)
            {
                var oneSignal = signalBits.Get(i)
                    ? GetOneSignal(i, signal, alternateCount, alternateSignal)
                    : NoSignal;

                rowOfSignals.Add(oneSignal);
            }

            return rowOfSignals.ToArray();
        }

        private static char GetOneSignal(int index, char signal, int? alternateCount, char? alternateSignal)
        {
            if (alternateCount.HasValue && alternateSignal.HasValue && (index + 1) % alternateCount == 0)
            {
                return alternateSignal.Value;
            }

            return signal;
        }
    }
}
