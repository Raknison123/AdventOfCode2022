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
            var day = new Day05(@"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2");

            Assert.AreEqual("CMZ", day.Part1);
        }

        [Test]
        public void SolvePart2_SmallExample_ReturnsCorrectValue()
        {
            var day = new Day05(@"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2");

            Assert.AreEqual("MCD", day.Part2);
        }
    }
}