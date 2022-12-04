using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal static class BackpackHelper
    {
        public static string FindOverlappingItems(this Backpack backpack1, Backpack backpack2)
        {
            return FindOverlappingItems(backpack1.ToString(), backpack2.ToString());
        }

        public static string FindOverlappingItems(this string input1, Backpack backpack2)
        {
            return FindOverlappingItems(input1, backpack2.ToString());
        }

        public static string FindOverlappingItems(this string input1, string input2)
        {
            var foundItems = new List<char>();

            foreach (var input1Characters in input1)
            {
                if (foundItems.Contains(input1Characters))
                {
                    continue;
                }

                foreach (var input2Characters in input2)
                {
                    if (input1Characters == input2Characters && !foundItems.Contains(input1Characters))
                    {
                        foundItems.Add(input1Characters);
                    }
                }
            }

            return new string(foundItems.ToArray());
        }

        public static int ConvertToScore(this string input)
        {
            var score = 0;
            var asciiBytes = Encoding.ASCII.GetBytes(input);
            foreach (var item in asciiBytes)
            {
                score += item < 91 ? item - 38 : item - 96;
            }
            return score;
        }
    }
}
