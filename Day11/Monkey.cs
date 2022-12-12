using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    internal class Monkey
    {
        public long InspectedItems = 0;
        public List<long> Items = new ();
        public string Operation = string.Empty;
        public string OperationValue = string.Empty;
        public string Test = string.Empty;
        public long TestValue;
        public int IfTrueThrowToMonkey;
        public int IfFalseThrowToMonkey;
    }
}
