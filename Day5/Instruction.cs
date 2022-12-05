using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    internal class Instruction
    {
        public Instruction() { }
        public Instruction(string raw)
        {
            var split = raw.Split(" ");
            Quantity = int.Parse(split[1]);
            From = int.Parse(split[3]);
            To = int.Parse(split[5]);
        }

        public int From = 0;
        public int To = 0;
        public int Quantity = 0;
    }
}
