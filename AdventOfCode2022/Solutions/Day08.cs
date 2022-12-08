using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Solutions
{
    public class Day08 : DayBase
    {
        private readonly int[,] _trees;

        public Day08(string input = null) : base(input)
        {
            // I wanted to do it with 2D arrays today. ;-)
            _trees = Input.Select(row => row.Select(c => int.Parse(c.ToString()))).To2DArray();
        }

        protected override object SolvePart1()
        {
            int?[,] visibleTrees = new int?[_trees.GetLength(0), _trees.GetLength(1)];

            // left-to-right:
            for (int y = 0; y < _trees.GetLength(1); y++)
            {
                var height = -1;
                for (int x = 0; x < _trees.GetLength(0); x++)
                {
                    if (height < _trees[x, y])
                    {
                        height = _trees[x, y];
                        visibleTrees[x, y] = _trees[x, y];
                    }
                }
            }

            // right-to-left
            for (int y = 0; y < _trees.GetLength(1); y++)
            {
                var height = -1;
                for (int x = _trees.GetLength(0) - 1; x >= 0; x--)
                {
                    if (height < _trees[x, y])
                    {
                        height = _trees[x, y];
                        visibleTrees[x, y] = _trees[x, y];
                    }
                }
            }

            // top-to-down
            for (int x = 0; x < _trees.GetLength(0); x++)
            {
                var height = -1;
                for (int y = 0; y < _trees.GetLength(1); y++)
                {
                    if (height < _trees[x, y])
                    {
                        height = _trees[x, y];
                        visibleTrees[x, y] = _trees[x, y];
                    }
                }
            }

            // down-to-top
            for (int x = 0; x < _trees.GetLength(0); x++)
            {
                var height = -1;
                for (int y = _trees.GetLength(1) - 1; y >= 0; y--)
                {
                    if (height < _trees[x, y])
                    {
                        height = _trees[x, y];
                        visibleTrees[x, y] = _trees[x, y];
                    }
                }
            }

            var count = 0;
            foreach (var field in visibleTrees)
            {
                if (field != null)
                {
                    count++;
                }
            }

            return count;
        }



        protected override object SolvePart2()
        {
            int?[,] scenicScores = new int?[_trees.GetLength(0), _trees.GetLength(1)];

            for (int outerY = 0; outerY < _trees.GetLength(1); outerY++)
            {
                for (int outerX = 0; outerX < _trees.GetLength(0); outerX++)
                {
                    int visibleTreeCountTop = 0;
                    int visibleTreeCountDown = 0;
                    int visibleTreeCountLeft = 0;
                    int visibleTreeCountRight = 0;

                    // left-to-right
                    var height = _trees[outerX, outerY];
                    for (int x = outerX + 1; x < _trees.GetLength(0); x++)
                    {
                        if (height >= _trees[x, outerY])
                        {
                            visibleTreeCountRight++;
                            if (height == _trees[x, outerY])
                            {
                                break;
                            }
                        }
                        else
                        {
                            visibleTreeCountRight++;
                            break;
                        }
                    }

                    // right-to-left
                    height = _trees[outerX, outerY];
                    for (int x = outerX - 1; x >= 0; x--)
                    {
                        if (height >= _trees[x, outerY])
                        {
                            visibleTreeCountLeft++;
                            if (height == _trees[x, outerY])
                            {
                                break;
                            }
                        }
                        else
                        {
                            visibleTreeCountLeft++;
                            break;
                        }
                    }


                    // top-to-down
                    height = _trees[outerX, outerY];
                    for (int y = outerY + 1; y < _trees.GetLength(1); y++)
                    {
                        if (height >= _trees[outerX, y])
                        {
                            visibleTreeCountDown++;
                            if (height == _trees[outerX, y])
                            {
                                break;
                            }
                        }
                        else
                        {
                            visibleTreeCountDown++;
                            break;
                        }
                    }

                    // down-to-top
                    height = _trees[outerX, outerY];
                    for (int y = outerY - 1; y >= 0; y--)
                    {
                        if (height >= _trees[outerX, y])
                        {
                            visibleTreeCountTop++;
                            if (height == _trees[outerX, y])
                            {
                                break;
                            }
                        }
                        else
                        {
                            visibleTreeCountTop++;
                            break;
                        }
                    }

                    scenicScores[outerX, outerY] = visibleTreeCountDown * visibleTreeCountLeft * visibleTreeCountRight * visibleTreeCountTop;
                }
            }


            var max = 0;
            foreach (var field in scenicScores)
            {
                if (field.Value > max)
                {
                    max = field.Value;
                }
            }

            return max;
        }
    }

    static class EnumerableExtensions
    {
        public static T[,] To2DArray<T>(this IEnumerable<IEnumerable<T>> source)
        {
            var data = source
                .Select(x => x.ToArray())
                .ToArray();

            var res = new T[data.Length, data.Max(x => x.Length)];
            for (var i = 0; i < data.Length; ++i)
            {
                for (var j = 0; j < data[i].Length; ++j)
                {
                    res[i, j] = data[j][i];
                }
            }

            return res;
        }
    }
}
