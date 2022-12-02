using AdventOfCode2022.Solutions;
using NUnit.Framework;
using System;

namespace AdventOfCode2022.Tests
{
    public class Day02Tests
    {
        [Test]
        public void SolvePart1_SmallExample_ReturnsCorrectValue()
        {
            var day = new Day02(@"A Y
B X
C Z");

            Assert.AreEqual(15, Convert.ToInt32(day.Part1));
        }

        [Test]
        public void SolvePart2_SmallExample_ReturnsCorrectValue()
        {
            var day = new Day02(@"A Y
B X
C Z");

            Assert.AreEqual(12, Convert.ToInt32(day.Part2));
        }
    }
}