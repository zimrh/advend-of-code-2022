using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    internal class SignalAnalyzer
    {
        public static int FindStartOfPacketMarker(string signal)
        {
            return FindUniqueCharacterBlock(signal, 4);
        }

        internal static object FindStartOfMessageMarker(string signal)
        {
            return FindUniqueCharacterBlock(signal, 14);
        }

        private static int FindUniqueCharacterBlock(string signal, int length)
        {
            var markerCounter = new Dictionary<char, int>();

            for (var i = 0; i < signal.Length; i++)
            {
                var input = signal[i];

                if (!markerCounter.ContainsKey(input))
                {
                    markerCounter[input] = 0;
                }

                markerCounter[input]++;

                if (i > length - 1)
                {
                    markerCounter[signal[i - length]]--;
                }

                if (MarkerPresent(markerCounter, length))
                {
                    return i + 1;
                }

            }

            return -1;
        }

        private static bool MarkerPresent(Dictionary<char, int> markerCounter, int markerLength)
        {
            var uniqueCount = markerCounter.Where(m => m.Value == 1);
            return uniqueCount.Count() == markerLength;
        }
    }
}
