using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Solutions
{
    public class Day10 : DayBase
    {
        public Day10(string input = null) : base(input)
        {

        }

        protected override object SolvePart1()
        {
            long registerX = 1;
            long signalStrength = 0;
            int currentInstruction = 0;

            int? currentAddx = null;
            for (int cycle = 1; cycle <= 220; cycle++)
            {
                if (cycle == 20 ||
                    cycle == 60 ||
                    cycle == 100 ||
                    cycle == 140 ||
                    cycle == 180 ||
                    cycle == 220)
                {
                    signalStrength += cycle * registerX;
                }

                if (currentAddx.HasValue)
                {
                    registerX += currentAddx.Value;
                    currentAddx = null;
                    continue;
                }

                var splitted = Input.ElementAtOrDefault(currentInstruction)?.Split(' ');
                if (splitted != null)
                {
                    switch (splitted[0])
                    {
                        case "addx":
                            currentAddx = Convert.ToInt32(splitted[1]);
                            break;
                    }

                    currentInstruction++;
                }
            }

            return signalStrength;
        }

        protected override object SolvePart2()
        {
            long registerX = 1;
            int currentInstruction = 0;

            var crtScreen = new Dictionary<(int x, int y), string>();

            int? currentAddx = null;
            for (int cycle = 1; cycle <= 240; cycle++)
            {
                var xPixelToDraw = (cycle - 1) % 40;
                crtScreen.Add((xPixelToDraw, (cycle - 1) / 40), Math.Abs(xPixelToDraw - registerX) <= 1 ? "#" : ".");

                if (currentAddx.HasValue)
                {
                    registerX += currentAddx.Value;
                    currentAddx = null;
                    continue;
                }

                var splitted = Input.ElementAtOrDefault(currentInstruction)?.Split(' ');
                if (splitted != null)
                {
                    switch (splitted[0])
                    {
                        case "addx":
                            currentAddx = Convert.ToInt32(splitted[1]);
                            break;
                    }

                    currentInstruction++;
                }
            }

            RenderImageToConsole(crtScreen);

            return null;
        }

        private static void RenderImageToConsole(Dictionary<(int x, int y), string> crtScreen)
        {
            for (int y = 0; y < 6; y++)
            {
                var row = new StringBuilder();
                for (int x = 0; x < 40; x++)
                {
                    row.Append(crtScreen[(x, y)]);
                }
                Console.WriteLine(row.ToString());
            }
        }
    }
}
