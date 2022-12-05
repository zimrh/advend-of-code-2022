using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    internal class Ship
    {
        public Dictionary<int, Stack<char>> Stacks = new();
        public List<Instruction> Instructions = new();

        public string ExecuteInstructions(Crane crane)
        {
            foreach (var instruction in Instructions)
            {
                switch (crane)
                {
                    case Crane.CrateMover9001:
                        ExecuteInstructionsWithCrateMoverCrane(instruction);
                        break;

                    default:
                        ExecuteInstructionWithBasicCrane(instruction);
                        break;
                }
            }

            return new string(Stacks.Select(s => s.Value.Peek()).ToArray());
        }

        private void ExecuteInstructionWithBasicCrane(Instruction instruction)
        {
            for (var i = 0; i < instruction.Quantity; i++)
            {
                var crate = Stacks[instruction.From - 1].Pop();
                Stacks[instruction.To - 1].Push(crate);
            }
        }

        private void ExecuteInstructionsWithCrateMoverCrane(Instruction instruction)
        {
            var craneHook = new Stack<char>();

            for (var i = 0; i < instruction.Quantity; i++)
            {
                var crate = Stacks[instruction.From - 1].Pop();
                craneHook.Push(crate);
            }

            for (var i = 0; i < instruction.Quantity; i++)
            {
                var crate = craneHook.Pop();
                Stacks[instruction.To - 1].Push(crate);
            }
        }
    }
}
