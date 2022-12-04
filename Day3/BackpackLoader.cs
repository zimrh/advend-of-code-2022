using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal class BackpackLoader
    {
        public async static Task<IList<Backpack>> LoadAsync(string path)
        {
            var backpacks = new List<Backpack>();

            await foreach(var line in FileLoader.GetLinesAsync(path))
            {
                backpacks.Add(new Backpack(line, 2));
            }

            return backpacks;
        }
    }
}
