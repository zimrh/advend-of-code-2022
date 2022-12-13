using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    internal static class PositionExtensions
    {
        public static Position MoveTo(this Position position, Move move)
        {
            return new Position
            {
                X = position.X + Movement(move)["stepX"],
                Y = position.Y + Movement(move)["stepY"]
            };
        }

        public static char GetCharacter(this ElevationMap elevation, Position position)
        {
            if (!elevation.PositionIsValid(position))
            {
                throw new IndexOutOfRangeException();
            }
            var character = elevation.Map[ElevationMap.MapIndex(position)].Value;

            return character switch
            {
                'S' => '`',
                'E' => '{',
                _ => elevation.Map[ElevationMap.MapIndex(position)].Value
            };
        }

        public static List<Move> GetScoredMoves(this ElevationMap elevation, Position currentPosition)
        {
            var moves = new Dictionary<Move, int>();
            foreach (var move in (Move[])Enum.GetValues(typeof(Move)))
            {
                var nextIndex = currentPosition.MoveTo(move);
                if (!PositionIsValid(elevation, nextIndex))
                {
                    continue;
                }

                var nextPosition = elevation.Map[nextIndex.ToIndex()];

                var nextChar = elevation.GetCharacter(nextPosition);
                var currentChar = elevation.GetCharacter(currentPosition);
                var diff = nextChar - currentChar;

                moves.Add(move, diff);
            }

            return moves.Where(m => m.Value >= -1).OrderBy(m => m.Value).Select(m => m.Key).ToList();
        }

        public static List<Move> GetDescendingScoredMoves(this ElevationMap elevation, Position currentPosition)
        {
            var moves = new Dictionary<Move, int>();
            foreach (var move in (Move[])Enum.GetValues(typeof(Move)))
            {
                var nextIndex = currentPosition.MoveTo(move);
                if (!PositionIsValid(elevation, nextIndex))
                {
                    continue;
                }

                var nextPosition = elevation.Map[nextIndex.ToIndex()];
                var diff = elevation.GetCharacter(nextPosition) - elevation.GetCharacter(currentPosition);
                moves.Add(move, diff);
            }

            return moves.Where(m => m.Value < 2).OrderByDescending(m => m.Value).Select(m => m.Key).ToList();
        }

        public static bool PositionIsValid(this ElevationMap elevation, Position position)
        {
            return position.X >= 0 && 
                position.X < elevation.Width &&
                position.Y >= 0 &&
                position.Y < elevation.Height;
        }

        private static Dictionary<string, int> Movement(Move move) =>
            move switch
            {
                Move.Up => new() { { "stepX", 0 }, { "stepY", 1 } },
                Move.Down => new() { { "stepX", 0 }, { "stepY", -1 } },
                Move.Left => new() { { "stepX", -1 }, { "stepY", 0 } },
                Move.Right => new() { { "stepX", 1 }, { "stepY", 0 } },
                _ => throw new NotImplementedException(),
            }; 
    }
}
