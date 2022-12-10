using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Solutions
{
    public class Day09 : DayBase
    {
        private readonly List<(string dir, int steps)> _instructions;

        public Day09(string input = null) : base(input)
        {
            _instructions = Input.Select(i =>
            {
                var split = i.Split(' ');
                return (dir: split[0], steps: Convert.ToInt32(split[1]));
            }).ToList();
        }

        protected override object SolvePart1()
        {
            return MoveRope(1);
        }

        protected override object SolvePart2()
        {
            return MoveRope(9);
        }

        private int MoveRope(int numberOfTails)
        {
            HashSet<(int x, int y)> visitedCoords = new();
            var nodeQueue = new Queue<(int x, int y)>();

            for (int i = 0; i <= numberOfTails; i++)
            {
                nodeQueue.Enqueue((0, 0));
            }

            foreach (var (dir, steps) in _instructions)
            {
                for (int step = 0; step < steps; step++)
                {
                    // Move head
                    var newHeadPos = MoveHeadOneStep(nodeQueue.Dequeue(), dir);
                    nodeQueue.Enqueue(newHeadPos);

                    // Move tails
                    (int x, int y) leadingTailPos = newHeadPos;
                    for (int tail = 1; tail <= numberOfTails; tail++)
                    {
                        var currentTailPos = nodeQueue.Dequeue();
                        var newTailPos = MoveTailOneStep(currentTailPos, leadingTailPos);
                        nodeQueue.Enqueue(newTailPos);
                        leadingTailPos = newTailPos;

                        if (tail == numberOfTails)
                        {
                            visitedCoords.Add(newTailPos);
                        }
                    }
                }
            }

            return visitedCoords.Count;
        }

        private static (int x, int y) MoveHeadOneStep((int x, int y) currentHeadPos, string dir)
        {
            switch (dir)
            {
                case "R":
                    currentHeadPos.x += 1;
                    break;
                case "L":
                    currentHeadPos.x -= 1;
                    break;
                case "U":
                    currentHeadPos.y -= 1;
                    break;
                case "D":
                    currentHeadPos.y += 1;
                    break;
            }

            return currentHeadPos;
        }

        private static (int x, int y) MoveTailOneStep((int x, int y) currentTailPos, (int x, int y) leadingTailPos)
        {
            int deltaX = leadingTailPos.x - currentTailPos.x;
            int deltaY = leadingTailPos.y - currentTailPos.y;

            if (deltaX == 2 && deltaY == 0)
            {
                currentTailPos.x += 1;
            }
            else if (deltaX == -2 && deltaY == 0)
            {
                currentTailPos.x -= 1;
            }
            else if (deltaX == 0 && deltaY == 2)
            {
                currentTailPos.y += 1;
            }
            else if (deltaX == 0 && deltaY == -2)
            {
                currentTailPos.y -= 1;
            }
            // up-left
            else if ((deltaX == -1 && deltaY == -2) ||
                     (deltaX == -2 && deltaY == -1) ||
                     (deltaX == -2 && deltaY == -2))
            {
                currentTailPos.x -= 1;
                currentTailPos.y -= 1;
            }
            // up-right
            else if ((deltaX == 1 && deltaY == -2) ||
                     (deltaX == 2 && deltaY == -1) ||
                      (deltaX == 2 && deltaY == -2))
            {
                currentTailPos.x += 1;
                currentTailPos.y -= 1;
            }
            // left-down
            else if ((deltaX == -1 && deltaY == 2) ||
                     (deltaX == -2 && deltaY == 1) ||
                      (deltaX == -2 && deltaY == 2))
            {
                currentTailPos.x -= 1;
                currentTailPos.y += 1;
            }
            // right-down
            else if ((deltaX == 1 && deltaY == 2) ||
                     (deltaX == 2 && deltaY == 1) ||
                     (deltaX == 2 && deltaY == 2))
            {
                currentTailPos.x += 1;
                currentTailPos.y += 1;
            }

            return currentTailPos;
        }
    }
}
