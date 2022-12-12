using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    internal class WorrySimulator
    {
        public static long GetMonkeyBusinessScore(List<Monkey> monkeys, int rounds, bool worryLevelsDecrease = true)
        {
            long product = 1;
            foreach(var monkey in monkeys)
            {
                product *= monkey.TestValue;
            }

            for (int i = 0; i < rounds; i++)
            {
                for (int monkey = 0; monkey < monkeys.Count; monkey++)
                {
                    var items = monkeys[monkey].Items.ToList();
                    monkeys[monkey].Items.Clear();

                    foreach (var item in items)
                    {
                        monkeys[monkey].InspectedItems++;

                        long newItemValue = item;
                        var operationValue = string.Equals(monkeys[monkey].OperationValue, "old") ? 
                            item :
                            long.Parse(monkeys[monkey].OperationValue);

                        switch (monkeys[monkey].Operation)
                        {
                            case "*":
                                newItemValue *= operationValue;
                                break;

                            case "+": newItemValue += operationValue;
                                break;
                            
                            default:
                                throw new NotImplementedException();
                        };

                        if (worryLevelsDecrease)
                        {
                            newItemValue /= 3;
                        }
                        else
                        {
                            // Based on a suggestion: https://www.reddit.com/r/adventofcode/comments/zifqmh/comment/izsn0a4
                            // Also thank you to Andrew Rylatt for the link in his code... Was pulling my hair out at 1am :(
                            newItemValue %= product;
                        }

                        var outcome = monkeys[monkey].Test switch
                        {
                            "divisible" => newItemValue % monkeys[monkey].TestValue == 0,
                            _ => throw new NotImplementedException(),
                        };

                        if (outcome)
                        {
                            var throwToMonkey = monkeys[monkey].IfTrueThrowToMonkey;
                            monkeys[throwToMonkey].Items.Add(newItemValue);
                        }
                        else
                        {
                            var throwToMonkey = monkeys[monkey].IfFalseThrowToMonkey;
                            monkeys[throwToMonkey].Items.Add(newItemValue);
                        }


                    }
                }
            }

            var top = monkeys.OrderByDescending(m => m.InspectedItems).Take(2).ToList();
            return top[0].InspectedItems * top[1].InspectedItems;
        }

        
    }
}
