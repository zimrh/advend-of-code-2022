using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    internal class Analyzer
    {
        private Dictionary<char, double> Registers = new Dictionary<char, double>();
        private double Cycle = 1;
        private double SignalStrength = 0;

        public Analyzer()
        {
            Registers.Add('x', 1);
        }

        public async Task<double> GetSignalStrenghtSum(string programPath)
        {
            await foreach (var line in FileLoader.GetLinesAsync(programPath))
            {
                ParseAndExecuteLine(line);
            }

            return SignalStrength;
        }

        private void ParseAndExecuteLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) { return; }

            var split = line.Split(' ');
            var command = split[0];
            IncrementCycle();

            if (command == "addx")
            {
                CheckCyclesAndAddIfNeeded();

                IncrementCycle();
                Registers[command[3]] += int.Parse(split[1]);
            }

            CheckCyclesAndAddIfNeeded();
        }

        private void IncrementCycle()
        {
            if ((Cycle - 1) % 40 == 0)
            {
                Console.WriteLine();
            }

            var pixelPos = Cycle - (Math.Floor(Cycle / 40) * 40) - 1;
            var distance = Registers['x'] - pixelPos;
            var overlapping = distance <= 1 && distance >= -1;

            Console.Write(overlapping ? '#' : '.');

            Cycle ++;
        }

        private void CheckCyclesAndAddIfNeeded()
        {
            if (Cycle == 20 || (Cycle - 20) % 40 == 0)
            {
                SignalStrength += Cycle * Registers['x'];
            }
        }
    }
}
