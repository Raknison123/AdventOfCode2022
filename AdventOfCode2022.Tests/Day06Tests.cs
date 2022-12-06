using AdventOfCode2022.Solutions;
using NUnit.Framework;
using System;

namespace AdventOfCode2022.Tests
{
    public class Day06Tests
    {
        [Test]
        public void SolvePart1_SmallExample_ReturnsCorrectValue()
        {
            var dayA = new Day06(@"bvwbjplbgvbhsrlpgdmjqwftvncz");
            Assert.AreEqual(5, dayA.Part1);

            var dayB = new Day06(@"nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg");
            Assert.AreEqual(10, dayB.Part1);
        }

        [Test]
        public void SolvePart2_SmallExample_ReturnsCorrectValue()
        {
            var day = new Day06(@"bvwbjplbgvbhsrlpgdmjqwftvncz");

            Assert.AreEqual(23, day.Part2);
        }
    }
}