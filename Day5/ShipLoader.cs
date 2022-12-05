using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    internal class ShipLoader
    {
        public async static Task<Ship> LoadAsync(string shipPath)
        {   
            var populatingMap = true;
            var startingMap = new List<string>();
            var ship = new Ship();

            await foreach (var line in FileLoader.GetLinesAsync(shipPath))
            {
                populatingMap &= !string.IsNullOrWhiteSpace(line);

                if (string.IsNullOrWhiteSpace(line)) { continue; }

                if (populatingMap)
                {
                    startingMap.Add(line);
                }
                else
                {
                    ship.Instructions.Add(new Instruction(line));
                }
            }

            for (var i = startingMap.Count - 2; i >= 0; i--)
            {
                for(var c = 3; c <= startingMap[i].Length; c += 4)
                {
                    if (!ship.Stacks.ContainsKey(c / 4))
                    {
                        ship.Stacks.Add(c / 4, new Stack<char>()); 
                    }

                    if (startingMap[i][c - 2] != ' ')
                    {
                        ship.Stacks[c / 4].Push(startingMap[i][c - 2]);
                    }
                }
            }

            return ship;
        }
    }
}
