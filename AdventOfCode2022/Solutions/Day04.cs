using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Solutions
{
    public class Day04 : DayBase
    {
        private readonly List<(string firstAssign, string secondAssign)> _pairs;

        public Day04(string input = null) : base(input)
        {
            _pairs = Input.Select(r =>
            {
                var splitted = r.Split(',');
                return (splitted[0], splitted[1]);
            }).ToList();
        }

        protected override object SolvePart1()
        {
            int fullyContainPairsCount = _pairs.Count(pair => pair.firstAssign.OverlapsAssignment(pair.secondAssign, true) ||
                                                              pair.secondAssign.OverlapsAssignment(pair.firstAssign, true));
            return fullyContainPairsCount;
        }



        protected override object SolvePart2()
        {
            var overlappingPairsCount = _pairs.Count(pair => pair.firstAssign.OverlapsAssignment(pair.secondAssign, false) ||
                                                             pair.secondAssign.OverlapsAssignment(pair.firstAssign, false));
            return overlappingPairsCount;
        }
    }

    public static class Day04Extensions
    {
        public static bool OverlapsAssignment(this string firstAssignment, string secondAssignment, bool mustFullyContainedBy)
        {
            var (firstFrom, firstTo) = ParseAssignment(firstAssignment);
            var (secondFrom, secondTo) = ParseAssignment(secondAssignment);

            bool overlaps;
            if (mustFullyContainedBy)
            {
                overlaps = secondFrom >= firstFrom &&
                           secondTo <= firstTo &&
                           secondTo >= firstFrom;
            }
            else
            {
                overlaps = secondFrom >= firstFrom &&
                           secondTo <= firstTo ||
                           secondTo >= firstFrom &&
                           secondTo <= firstTo;
            }

            return overlaps;
        }

        private static (int from, int to) ParseAssignment(string assignment)
        {
            var splAssignment = assignment.Split('-');
            int assignmFrom = Convert.ToInt32(splAssignment[0]);
            int assignmTo = Convert.ToInt32(splAssignment[1]);

            return (assignmFrom, assignmTo);
        }
    }
}
