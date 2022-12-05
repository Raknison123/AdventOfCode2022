using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Solutions
{
    public class Day05 : DayBase
    {
        private readonly Dictionary<int, Stack<char>> _stacks = new Dictionary<int, Stack<char>>();

        public Day05(string input = null) : base(input)
        {

        }

        protected override object SolvePart1()
        {
            return MoveStacks(InitializeStacksAndGetRearrangementProc(), false);
        }

        protected override object SolvePart2()
        {
            return MoveStacks(InitializeStacksAndGetRearrangementProc(), true);
        }

        private string MoveStacks(IEnumerable<string> moves, bool canMoveMultipleStacks)
        {
            foreach (var move in moves)
            {
                var splitted = move.Split("from");
                int elementsToMoveCount = Convert.ToInt32(splitted[0].Replace("move", ""));
                var moveFromTo = splitted[1].Split("to").Select(int.Parse).ToList();

                var pickedCrates = new List<char>();
                for (int i = 0; i < elementsToMoveCount; i++)
                {
                    pickedCrates.Add(_stacks[moveFromTo[0]].Pop());
                }

                if (canMoveMultipleStacks)
                {
                    pickedCrates.Reverse();
                }

                foreach (var crate in pickedCrates)
                {
                    _stacks[moveFromTo[1]].Push(crate);
                }
            }

            var moveOrder = new StringBuilder();
            foreach (var stack in _stacks)
            {
                moveOrder.Append(stack.Value.Pop());
            }

            return moveOrder.ToString();
        }

        private IEnumerable<string> InitializeStacksAndGetRearrangementProc()
        {
            var stackDefinition = Input.Where(r => (r.StartsWith(" ") && r.Trim().Length != 0) || r.StartsWith("[")).ToList();
            var rearrangementProc = Input.Where(r => r.StartsWith("move"));

            for (int i = stackDefinition.Count - 2; i >= 0; i--)
            {
                var stackRow = stackDefinition[i];
                var stackId = 0;
                for (int j = 1; j < stackRow.Length; j += 4)
                {
                    stackId++;
                    var crate = stackRow[j];
                    if (!char.IsWhiteSpace(crate) &&
                        !_stacks.TryAdd(stackId, new Stack<char>(new List<char> { crate })))
                    {
                        _stacks[stackId].Push(crate);
                    }
                }
            }

            return rearrangementProc;
        }
    }
}
