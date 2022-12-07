using AdventOfCode2022.Solutions;
using NUnit.Framework;
using System;

namespace AdventOfCode2022.Tests
{
    public class Day07Tests
    {
        [Test]
        public void SolvePart1_SmallExample_ReturnsCorrectValue()
        {
            var day = new Day07(@"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k");
            Assert.AreEqual(95437, day.Part1);
        }

        [Test]
        public void SolvePart2_SmallExample_ReturnsCorrectValue()
        {
            var day = new Day07(@"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k");

            Assert.AreEqual(24933642, day.Part2);
        }
    }
}