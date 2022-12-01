using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class ElfLoader
    {
        public static List<Elf> Load(string caloriesFilePath)
        {
            using var caloriesFile = File.OpenText(caloriesFilePath);

            var elfs = new List<Elf>();
            var items = new List<int>();

            do
            {
                var input = caloriesFile.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    elfs.Add(new Elf(items));
                    items.Clear();
                }
                else
                {
                    var intValue = Convert.ToInt32(input);
                    items.Add(intValue);
                }

            } while(!caloriesFile.EndOfStream);

            elfs.Add(new Elf(items));

            return elfs;
        }
    }
}
