using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class File
    {
        public Guid Id = Guid.NewGuid();
        public string Name = string.Empty;
        public double Size;
    }
}
