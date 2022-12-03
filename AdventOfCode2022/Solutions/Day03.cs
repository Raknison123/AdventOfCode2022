using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Solutions
{
    public class Day03 : DayBase
    {
        private readonly List<string> _rucksacks;

        public Day03(string input = null) : base(input)
        {
            _rucksacks = Input.ToList();
        }

        protected override object SolvePart1()
        {
            int prioritySum = 0;
            foreach (var rucksack in _rucksacks)
            {
                var compartmentSize = rucksack.Length / 2;
                var firstComp = rucksack.Take(compartmentSize);
                var secondComp = rucksack.Skip(compartmentSize).Take(compartmentSize);

                var duplicateItem = firstComp.Intersect(secondComp).Single();
                prioritySum += CalculatePriority(duplicateItem);
            }

            return prioritySum;
        }

        protected override object SolvePart2()
        {
            int prioritySum = 0;
            foreach (var groupOfThree in _rucksacks.Chunk(3))
            {
                var badgeItem = groupOfThree[0].Intersect(groupOfThree[1]).Intersect(groupOfThree[2]).Single();
                prioritySum += CalculatePriority(badgeItem);
            }

            return prioritySum;
        }

        private static int CalculatePriority(char item)
        {
            return char.IsUpper(item) ? item - 38 : item - 96;
        }
    }
}
