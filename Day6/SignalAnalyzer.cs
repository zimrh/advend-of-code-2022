using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    internal class SignalAnalyzer
    {
        private readonly Queue<char> _buffer = new();
        public int BlockSize = 0;
        public int MessagePosition = 0;
        public int MarkerPosition = -1;
        public bool MarkerFound = false;

        public SignalAnalyzer(int blockSize)
        {
            BlockSize = blockSize;
        }

        public void AddInput(char input)
        {
            _buffer.Enqueue(input);

            MessagePosition++;

            if (_buffer.Count > BlockSize)
            {
                _buffer.Dequeue();
            }

            CheckForUniqueCharacterBlock(_buffer, BlockSize);
        }

        private void CheckForUniqueCharacterBlock(Queue<char> buffer, int length)
        {
            var marker = new Dictionary<char, bool>();

            foreach (var c in buffer.ToList())
            {
                if (marker.ContainsKey(c))
                {
                    return;
                }

                marker[c] = true;
            }

            if (MarkerPresent(marker, length))
            {
                // Would probably set this to trigger an event instead of setting a flag
                MarkerFound = true;
                MarkerPosition = MessagePosition;
            }
        }

        private static bool MarkerPresent(Dictionary<char, bool> marker, int markerLength)
        {
            var uniqueCount = marker.Where(m => m.Value == true);
            return uniqueCount.Count() == markerLength;
        }
    }
}
