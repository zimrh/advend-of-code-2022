using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    internal class Position
    {
        public int X;
        public int Y;
        public string Parent = string.Empty;
        public char Value;
        public bool HasBeenVisited;

        public string ToIndex()
        {
            return $"{X}:{Y}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            var comparedPos = (Position)obj;
            return X == comparedPos.X && Y == comparedPos.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
