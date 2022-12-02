using AdventOfCode2022.Solutions;
using System;

namespace AdventOfCode2022
{
    class Program
    {
        static void Main(string[] args)
        {
            var puzzle = new Day02();
            Console.WriteLine($"{puzzle.GetType().Name} - Part1:{puzzle.Part1}, Part2:{puzzle.Part2}");
            Console.ReadKey();
        }
    }
}
