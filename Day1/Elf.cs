using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Elf
    {
        public List<int> FoodItems;
        public int FoodItemsTotalCalories => FoodItems.Sum();

        public Elf(List<int> foodItems)
        {
            FoodItems = foodItems.ToList();
        }
    }
}
