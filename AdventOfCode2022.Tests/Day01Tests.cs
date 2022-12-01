using AdventOfCode2022.Solutions;
using NUnit.Framework;
using System;

namespace AdventOfCode2022.Tests
{
    public class Day01Tests
    {
        [Test]
        public void SolvePart1_SmallExample_ReturnsCorrectValue()
        {
            var day01 = new Day01(@"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000");

            Assert.AreEqual(24000, Convert.ToInt32(day01.Part1));
        }

        [Test]
        public void SolvePart2_SmallExample_ReturnsCorrectValue()
        {
            var day01 = new Day01(@"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000");

            Assert.AreEqual(45000, Convert.ToInt32(day01.Part2));
        }
    }
}