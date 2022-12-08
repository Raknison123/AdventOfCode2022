using AdventOfCode2022.Solutions;
using NUnit.Framework;
using System;

namespace AdventOfCode2022.Tests
{
    public class Day08Tests
    {
        [Test]
        public void SolvePart1_SmallExample_ReturnsCorrectValue()
        {
            var day = new Day08(@"30373
25512
65332
33549
35390");
            Assert.AreEqual(21, day.Part1);
        }

        [Test]
        public void SolvePart2_SmallExample_ReturnsCorrectValue()
        {
            var day = new Day08(@"30373
25512
65332
33549
35390");

            Assert.AreEqual(8, day.Part2);
        }
    }
}