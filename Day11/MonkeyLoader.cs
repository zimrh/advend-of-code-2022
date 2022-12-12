using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    internal class MonkeyLoader
    {
        public async static Task<List<Monkey>> LoadAsync(string monkeyPath)
        {
            var monkeys = new List<Monkey>();
            var monkey = -1;

            await foreach (var line in FileLoader.GetLinesAsync(monkeyPath))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                switch(split[0])
                {
                    case "Monkey":
                        monkeys.Add(new Monkey());
                        monkey++;
                        break;

                    case "Starting":
                        monkeys[monkey].Items = line.Split(':')[1].Split(',').Select(i => long.Parse(i)).ToList();
                        break;

                    case "Operation:":
                        var operations = line.Split('=')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        monkeys[monkey].Operation = operations[1];
                        monkeys[monkey].OperationValue = operations[2];
                        break;

                    case "Test:":
                        var tests = line.Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        monkeys[monkey].Test = tests[0];
                        monkeys[monkey].TestValue = long.Parse(tests[2]);
                        break;

                    case "If":
                        var ifs = line.Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        var value = int.Parse(ifs[3]);
                        if (string.Equals(split[1], "true:"))
                        {
                            monkeys[monkey].IfTrueThrowToMonkey = value;
                        }
                        else
                        {
                            monkeys[monkey].IfFalseThrowToMonkey = value;
                        }
                        break;
                };
            }

            return monkeys;
        }
    }
}
