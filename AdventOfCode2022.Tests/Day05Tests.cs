using AdventOfCode2022.Solutions;
using NUnit.Framework;
using System;

namespace AdventOfCode2022.Tests
{
    public class Day05Tests
    {
        [Test]
        public void SolvePart1_SmallExample_ReturnsCorrectValue()
        {
            var day = new Day05(@"");

            Assert.AreEqual(0, Convert.ToInt32(day.Part1));
        }

        [Test]
        public void SolvePart2_SmallExample_ReturnsCorrectValue()
        {
            var day = new Day05(@"");

            Assert.AreEqual(0, Convert.ToInt32(day.Part2));
        }
    }
}