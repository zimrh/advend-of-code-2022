using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    internal class TreesLoader
    {
        public async static Task<Forest> LoadAsync(string TreesFilePath)
        {
            var trees = new Dictionary<int, Dictionary<int, int>>();
            var y = 0;
            
            await foreach (var line in FileLoader.GetLinesAsync(TreesFilePath))
            {
                if (string.IsNullOrWhiteSpace(line)) { continue; }
                
                var x = 0;
                foreach(var c in line)
                {
                    if (!trees.ContainsKey(x))
                    {
                        trees.Add(x, new Dictionary<int, int>());
                    }
                    trees[x].Add(y, int.Parse(c.ToString()));
                    x++;
                }

                y++;
            }

            return new Forest(trees);
        }
    }
}
