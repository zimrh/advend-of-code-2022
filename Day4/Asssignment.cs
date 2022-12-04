using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class Assignment
    {
        public int Start;
        public int End;

        public Assignment(string input)
        {
            var split = input.Split('-');
            Start = int.Parse(split[0]);
            End = int.Parse(split[1]);
        }

        public bool Contains(Assignment other)
        {
            return Start <= other.Start && End >= other.End;
        }

        internal bool HasAnyOverlap(Assignment other)
        {
            // Note: Needed to draw a couple of lines on a piece of paper for this as found myself making a WAY too complex logic check.
            return !(End < other.Start || Start > other.End);
        }
    }
}
