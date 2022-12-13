using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    internal class ElevationMap
    {
        public Position Start = new ();
        public Position End = new ();
        public Dictionary<string, Position> Map = new ();
        public int Width = 0;
        public int Height = 0;

        public static string MapIndex(Position pos)
        {
            return MapIndex(pos.X, pos.Y);
        }

        public static string MapIndex(int x, int y)
        {
            return $"{x}:{y}";
        }

        public void ToConsole()
        {
            for (int y = Height - 1; y >= 0; y--)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.SetCursorPosition(x, Height - y);
                    Console.Write(Map[MapIndex(x, y)].Value);
                }
            }
        }

        public void Draw(Position currentPos, char character)
        {
            Console.SetCursorPosition(currentPos.X, Height - currentPos.Y);
            Console.Write(character);
        }

        internal int GetShortestDescent()
        {
            Console.Clear();
            ToConsole();

            var indexQueue = new Queue<string>();
            var start = Map[End.ToIndex()];
            start.HasBeenVisited = true;

            indexQueue.Enqueue(start.ToIndex());

            while (indexQueue.Count > 0)
            {
                var currentIndex = indexQueue.Dequeue();
                var currentPosition = Map[currentIndex];

                if (currentPosition.Value == 'a')
                {
                    var count = 0;
                    do
                    {
                        currentPosition = Map[currentPosition.Parent];
                        Draw(currentPosition, '*');
                        count++;
                        if (start.Equals(currentPosition))
                        {
                            return count;
                        }
                    } while (true);
                }

                foreach (var move in this.GetScoredMoves(currentPosition))
                {
                    var next = currentPosition.MoveTo(move);

                    if (!this.PositionIsValid(next))
                    {
                        continue;
                    }

                    var nextPosition = Map[next.ToIndex()];

                    if (nextPosition.HasBeenVisited)
                    {
                        continue;
                    }

                    var nextChar = this.GetCharacter(nextPosition);
                    var currentChar = this.GetCharacter(currentPosition);
                    var diff = nextChar - currentChar;
                    if (diff < -1)
                    {
                        continue;
                    }

                    nextPosition.HasBeenVisited = true;
                    nextPosition.Parent = currentPosition.ToIndex();
                    indexQueue.Enqueue(nextPosition.ToIndex());

                    foreach (var pos in indexQueue)
                    {
                        Draw(Map[pos], '.');
                    }
                }
            }

            return -1;
        }

        internal int GetShortestClimb()
        {
            Console.Clear();
            ToConsole();

            var indexQueue = new Queue<string>();
            var start = Map[Start.ToIndex()];
            start.HasBeenVisited = true;

            indexQueue.Enqueue(start.ToIndex());

            while (indexQueue.Count > 0)
            {
                var currentIndex = indexQueue.Dequeue();
                var currentPosition = Map[currentIndex];

                if (currentPosition.Equals(End))
                {
                    var count = 0;
                    do
                    {
                        currentPosition = Map[currentPosition.Parent];
                        Draw(currentPosition, '*');
                        count++;
                        if (Start.Equals(currentPosition))
                        {
                            return count;
                        }
                    } while (true);
                }

                foreach (var move in this.GetDescendingScoredMoves(currentPosition))
                {
                    var next = currentPosition.MoveTo(move);

                    if (!this.PositionIsValid(next))
                    {
                        continue;
                    }

                    var nextPosition = Map[next.ToIndex()];

                    if (nextPosition.HasBeenVisited)
                    {
                        continue;
                    }

                    var diff = this.GetCharacter(nextPosition) - this.GetCharacter(currentPosition);
                    if (diff > 1)
                    {
                        continue;
                    }

                    nextPosition.HasBeenVisited = true;
                    nextPosition.Parent = currentPosition.ToIndex();   
                    indexQueue.Enqueue(nextPosition.ToIndex());

                    foreach (var pos in indexQueue)
                    {
                        Draw(Map[pos], '.');
                    }
                }
            }

            return -1;
        }

    }


}
