using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class ElfLoader
    {
        public static async Task<List<Elf>> LoadAsync(string caloriesFilePath)
        {
            var elfs = new List<Elf>();
            var items = new List<int>();

            await foreach(var line in FileLoader.GetLinesAsync(caloriesFilePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    elfs.Add(new Elf(items));
                    items.Clear();
                }
                else
                {
                    var intValue = Convert.ToInt32(line);
                    items.Add(intValue);
                }
            }

            elfs.Add(new Elf(items));

            return elfs;
        }
    }
}
