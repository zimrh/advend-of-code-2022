using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    internal class Forest
    {
        public Dictionary<int, Dictionary<int, int>> Trees { get; set; }
        public int Width => Trees.Count;
        public int Height => Trees[0].Count;

        public Forest(Dictionary<int, Dictionary<int, int>> trees)
        {
            Trees = trees;
        }

        public double GetHighestViewingScore()
        {
            var scores = new Dictionary<int, Dictionary<int, double>>();

            for (var x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                { 
                    if (!scores.ContainsKey(x))
                    {
                        scores.Add(x, new Dictionary<int, double>());
                    }
                    
                    scores[x].Add(y, 1);
                    
                    foreach (var direction in (Directions[])Enum.GetValues(typeof(Directions)))
                    {
                        var distance = VisabilityDistance(direction, x, y);
                        scores[x][y] *= distance;
                    }
                }
            }

            double highest = 0;
            for (var x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {

                    Console.Write($"{Trees[y][x]} ");
                    highest = scores[x][y] > highest ? scores[x][y] : highest;
                }
                Console.WriteLine();
            }

            return highest;
        }

        public int FindVisibleTreesCount()
        {
            var visible = new Dictionary<int, Dictionary<int, bool>>();

            for (var x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (!visible.ContainsKey(x))
                    {
                        visible.Add(x, new Dictionary<int, bool>());
                    }

                    visible[x].Add(y, false);

                    if (visible[x][y])
                    {
                        continue;
                    }
                    foreach (var direction in (Directions[]) Enum.GetValues(typeof(Directions)))
                    {
                        visible[x][y] |= IsTreeVisible(direction, x, y);
                    }
                }
            }

            var count = 0;
            for (var x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {

                    Console.Write($"{Trees[y][x]} ");
                    count += visible[x][y] ? 1 : 0;
                }
                Console.WriteLine();
            }

            return count;
        }

        private int VisabilityDistance(Directions direction, int x, int y)
        {
            var instructions = Instructions[direction];
            var stepX = x + instructions["xStep"];
            var stepY = y + instructions["yStep"];
            var distance = 0;

            while (!(stepX < 0 || stepY < 0 || stepX >= Width || stepY >= Height))
            {
                distance++;
                if (Trees[x][y] <= Trees[stepX][stepY])
                {
                    return distance;
                }
                stepX += instructions["xStep"];
                stepY += instructions["yStep"];
            }

            return distance;
        }

        private bool IsTreeVisible(Directions direction, int x, int y)
        {
            var instructions = Instructions[direction];
            var stepX = x + instructions["xStep"];
            var stepY = y + instructions["yStep"];

            while (!(stepX < 0 || stepY < 0 || stepX >= Width  || stepY >= Height))
            {
                if (Trees[x][y] <= Trees[stepX][stepY])
                {
                    return false;
                }
                stepX += instructions["xStep"];
                stepY += instructions["yStep"];
            }

            return true;
        }

        public Dictionary<Directions, Dictionary<string, int>> Instructions = new Dictionary<Directions, Dictionary<string, int>> 
        {
            { Directions.North, new Dictionary<string, int> {{ "xStep", -1 }, { "yStep", 0 }}},
            { Directions.South, new Dictionary<string, int> {{ "xStep", 1 }, { "yStep", 0 }}},
            { Directions.West, new Dictionary<string, int> {{ "xStep", 0 }, { "yStep", -1 }}},
            { Directions.East, new Dictionary<string, int> {{ "xStep", 0 }, { "yStep", 1 }}}
        };

    }

    internal enum Directions
    {
        North,
        South,
        East,
        West
    }
}
