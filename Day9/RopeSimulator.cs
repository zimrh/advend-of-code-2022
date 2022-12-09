using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    internal class RopeSimulator
    {
        public async static Task<int> GetTailMovementCount(string ropesFile, int knots)
        {
            var rope = new List<Item>();
            var lastKnot = knots - 1;

            for (int i = 0; i < knots; i++)
            {
                rope.Add(new Item());
            }
            
            var visitedPlaces = new HashSet<string>
            {
                $"{rope[lastKnot].X},{rope[lastKnot].Y}"
            };

            await foreach (var line in FileLoader.GetLinesAsync(ropesFile))
            {
                var split = line.Split(' ');
                var direction = Movement.ParseDirection(split[0]);
                var count = int.Parse(split[1]);

                for (int i = 0; i < count; i++)
                {
                    rope[0].Move(direction);

                    for (int r = 1; r < rope.Count; r++)
                    {
                        var chaseDirection = Movement.GetDirectionToChaseTarget(rope[r], rope[r - 1]);
                        rope[r].Move(chaseDirection);
                    }

                    visitedPlaces.Add($"{rope[lastKnot].X},{rope[lastKnot].Y}");
                }
            }

            return visitedPlaces.Count;
        }
    }
}
