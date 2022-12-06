using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Solutions
{
    public class Day06 : DayBase
    {
        public Day06(string input = null) : base(input)
        {

        }

        protected override object SolvePart1()
        {
            return GetMarker(4);
        }

     

        protected override object SolvePart2()
        {
            return GetMarker(14);
        }

        private int GetMarker(int numOfDistinctChars)
        {
            for (int i = 0; i < InputComplete.Length - numOfDistinctChars; i++)
            {
                var hashSet = new HashSet<char>();
                for (int j = 0; j < numOfDistinctChars; j++)
                {
                    hashSet.Add(InputComplete[i + j]);
                }

                if (hashSet.Count == numOfDistinctChars)
                {
                    return i + numOfDistinctChars;
                }
            }

            return int.MaxValue;
        }
    }
}
