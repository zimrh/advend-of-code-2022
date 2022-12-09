using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    internal class Item
    {
        public int X;
        public int Y;

        public void Move(Move direction)
        {
            var instruction = Movement.Instructions(direction);
            X += instruction["stepX"];
            Y += instruction["stepY"];
        }
    }
}
