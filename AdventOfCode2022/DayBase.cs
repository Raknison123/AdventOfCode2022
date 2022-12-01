using System;
using System.Diagnostics;
using System.Net.Http;

namespace AdventOfCode2021
{
    public abstract class DayBase
    {
        protected string[] Input;
        protected string InputComplete;

        protected DayBase(string input = null)
        {
            if (string.IsNullOrEmpty(input))
            {
                DownloadPuzzleInput();
            }
            else
            {
                Input = input.TrimEnd('\n').Split(new string[] { "\n", "\r\n", "\r" }, StringSplitOptions.None);
                InputComplete = input;
            }
        }

        private void DownloadPuzzleInput()
        {
            var httpRequest = new HttpClient
            {
                BaseAddress = new Uri("https://adventofcode.com"),
            };

            var query = @$"2022/day/{Convert.ToInt32(this.GetType().Name.Replace("Day", string.Empty))}/input";
            httpRequest.DefaultRequestHeaders.Add("Cookie", Environment.GetEnvironmentVariable("aocSessionCookie", EnvironmentVariableTarget.User));
            var result = httpRequest.GetStringAsync(query).GetAwaiter().GetResult();
            Input = result.TrimEnd('\n').Split(new string[] { "\n", "\r\n", "\r" }, StringSplitOptions.None);
            InputComplete = result;
        }

        public object Part1
        {
            get
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var result = SolvePart1();
                Console.WriteLine($"Time elapsed:{stopWatch.ElapsedMilliseconds}ms");
                return result;
            }
        }

        public object Part2
        {
            get
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var result = SolvePart2();
                Console.WriteLine($"Time elapsed:{stopWatch.ElapsedMilliseconds}ms");
                return result;
            }
        }

        protected abstract object SolvePart1();

        protected abstract object SolvePart2();
    }
}