using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Solutions
{
    public class Day01 : DayBase
    {
        private readonly List<int> _elvesCalories;

        public Day01(string input = null) : base(input)
        {
            _elvesCalories = InputComplete.Split(new string[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(elf => elf.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                                              .Sum(int.Parse)).ToList();
        }

        protected override object SolvePart1()
        {
            return _elvesCalories.Max();
        }

        protected override object SolvePart2()
        {
            return _elvesCalories.OrderByDescending(c => c).Take(3).Sum();
        }
    }
}
