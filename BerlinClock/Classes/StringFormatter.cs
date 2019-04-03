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
            builder.Append(GetSignals(timeModel.FiveHours, RedSignal)).AppendLine();
            builder.Append(GetSignals(timeModel.Hours, RedSignal)).AppendLine();
            builder.Append(GetSignals(timeModel.FiveMinutes, YellowSignal,
                BerlinTimeModel.MinuteSignalsAlternateCount, RedSignal)).AppendLine();
            builder.Append(GetSignals(timeModel.Minutes, YellowSignal));

            return builder.ToString();
        }

        private static char[] GetSignals(BitArray signalBits, char signal)
        {
            return GetSignals(signalBits, signal, 1, signal);
        }

        private static char[] GetSignals(
            BitArray signalBits, 
            char signal, 
            int alternateCount, 
            char alternateSignal)
        {
            var signals = new List<char>();

            for (var i = 0; i < signalBits.Count; i++)
            {
                if (signalBits.Get(i))
                {
                    signals.Add((i + 1) % alternateCount == 0 ? alternateSignal : signal);
                }
                else
                {
                    signals.Add(NoSignal);
                }
            }

            return signals.ToArray();
        }
    }
}
