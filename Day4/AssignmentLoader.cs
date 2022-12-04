using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class AssignmentLoader
    {
        public const int ElvesPerGroup = 2;

        public async static Task<List<List<Assignment>>> LoadAsync(string path)
        {
            var groups = new List<List<Assignment>>();
            await foreach (var line in FileLoader.GetLinesAsync(path))
            {
                groups.Add(line.Split(',').Select(x => new Assignment(x)).ToList());
            }
            return groups;
        }
    }
}
