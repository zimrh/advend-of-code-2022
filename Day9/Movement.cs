using Day9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    internal static class Movement
    {
        public static Move GetDirectionToChaseTarget(Item location, Item target)
        {
            const int proximity = 1;
            var xDiff = target.X - location.X;
            var yDiff = target.Y - location.Y;

            // Within Proximity
            if (xDiff <= proximity && xDiff >= -proximity && yDiff <= proximity && yDiff >= -proximity)
            {
                return Move.None;
            }

            // Left/Right
            if (yDiff == 0)
            {
                return xDiff > 0 ? Move.Right : Move.Left;
            }

            // Up/Down
            if (xDiff == 0)
            {
                return yDiff > 0 ? Move.Up : Move.Down;
            }

            // Move Up
            if (yDiff > 0)
            {
                return xDiff > 0 ? Move.DiagonalUpRight : Move.DiagonalUpLeft;
            }

            // Move Down
            return xDiff > 0 ? Move.DiagonalDownRight : Move.DiagonalDownLeft;
        }

        public static Move ParseDirection(string input) =>
            input switch
            {
                "U" => Move.Up,
                "D" => Move.Down,
                "L" => Move.Left,
                "R" => Move.Right,
                _ => throw new NotImplementedException()
            };

        public static Dictionary<string, int> Instructions(Move direction) =>
            direction switch
            {
                Move.None => new() { { "stepX", 0 }, { "stepY", 0 } },
                Move.Up => new() { { "stepX", 0 }, { "stepY", 1 } },
                Move.Down => new() { { "stepX", 0 }, { "stepY", -1 } },
                Move.Left => new() { { "stepX", -1 }, { "stepY", 0 } },
                Move.Right => new() { { "stepX", 1 }, { "stepY", 0 } },
                Move.DiagonalUpLeft => new() { { "stepX", -1 }, { "stepY", 1 } },
                Move.DiagonalUpRight => new() { { "stepX", 1 }, { "stepY", 1 } },
                Move.DiagonalDownLeft => new() { { "stepX", -1 }, { "stepY", -1 } },
                Move.DiagonalDownRight => new() { { "stepX", 1 }, { "stepY", -1 } },
                _ => throw new NotImplementedException()
            };
    }
}
