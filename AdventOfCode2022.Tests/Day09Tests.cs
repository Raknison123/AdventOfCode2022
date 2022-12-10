using AdventOfCode2022.Solutions;
using NUnit.Framework;
using System;

namespace AdventOfCode2022.Tests
{
    public class Day09Tests
    {
        [Test]
        public void SolvePart1_SmallExample_ReturnsCorrectValue()
        {
            var day = new Day09(@"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2");
            Assert.AreEqual(13, day.Part1);
        }

        [Test]
        public void SolvePart2_SmallExample_ReturnsCorrectValue()
        {
            var dayY = new Day09(@"R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20");

            Assert.AreEqual(36, dayY.Part2);
        }
    }
}