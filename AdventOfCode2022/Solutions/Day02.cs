using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Solutions
{
    public class Day02 : DayBase
    {
        private readonly List<string[]> _gameStrategy;

        public Day02(string input = null) : base(input)
        {
            _gameStrategy = InputComplete.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(elf => elf.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                                  .ToList();
        }

        protected override object SolvePart1()
        {
            int totalPoints = 0;
            foreach (string[] game in _gameStrategy)
            {
                var opponentChoice = MapChoice(game[0][0]);
                var playerChoice = MapChoice(game[1][0]);
                (int points, GameResult _) = GetGameResult(playerChoice, opponentChoice);
                totalPoints += points;
            }

            return totalPoints;
        }

        protected override object SolvePart2()
        {
            int totalPoints = 0;
            foreach (string[] game in _gameStrategy)
            {
                var desiredResult = MapDesiredResult(game[1][0]);
                var opponentChoice = MapChoice(game[0][0]);
                int points = GetDesiredGameResult(opponentChoice, desiredResult);
                totalPoints += points;
            }

            return totalPoints;
        }

        private int GetDesiredGameResult(Choice opponentChoice, GameResult desiredResult)
        {
            var possibleResults = new List<(int points, GameResult result)>();
            possibleResults.Add(GetGameResult(Choice.Rock, opponentChoice));
            possibleResults.Add(GetGameResult(Choice.Scissor, opponentChoice));
            possibleResults.Add(GetGameResult(Choice.Paper, opponentChoice));

            return possibleResults.Single(r => r.result == desiredResult).points;
        }

        private (int points, GameResult result) GetGameResult(Choice playerChoice, Choice opponentChoice)
        {
            int gamePoints = 0;
            GameResult result = GameResult.Loose;

            switch (opponentChoice)
            {
                case Choice.Rock:
                    if (playerChoice == Choice.Paper)
                    {
                        result = GameResult.Win;
                    }
                    else if (playerChoice == Choice.Scissor)
                    {
                        result = GameResult.Loose;
                    }
                    else if (playerChoice == Choice.Rock)
                    {
                        result = GameResult.Draw;
                    }
                    break;
                case Choice.Paper:
                    if (playerChoice == Choice.Paper)
                    {
                        result = GameResult.Draw;
                    }
                    else if (playerChoice == Choice.Scissor)
                    {
                        result = GameResult.Win;
                    }
                    else if (playerChoice == Choice.Rock)
                    {
                        result = GameResult.Loose;
                    }
                    break;
                case Choice.Scissor:
                    if (playerChoice == Choice.Paper)
                    {
                        result = GameResult.Loose;
                    }
                    else if (playerChoice == Choice.Scissor)
                    {
                        result = GameResult.Draw;
                    }
                    else if (playerChoice == Choice.Rock)
                    {
                        result = GameResult.Win;
                    }
                    break;
            }

            gamePoints += (int)result + (int)playerChoice;

            return (gamePoints, result);
        }

        private Choice MapChoice(char choiceChar)
        {
            Choice choice = Choice.Undefined;
            switch (choiceChar)
            {
                case 'X':
                case 'A':
                    choice = Choice.Rock;
                    break;
                case 'Y':
                case 'B':
                    choice = Choice.Paper;
                    break;
                case 'Z':
                case 'C':
                    choice = Choice.Scissor;
                    break;
            }

            return choice;
        }

        private GameResult MapDesiredResult(char desiredResultChar)
        {
            GameResult result = GameResult.Draw;
            switch (desiredResultChar)
            {
                case 'X':
                    result = GameResult.Loose;
                    break;
                case 'Y':
                    result = GameResult.Draw;
                    break;
                case 'Z':
                    result = GameResult.Win;
                    break;
            }

            return result;
        }
    }

    enum Choice
    {
        Undefined = 0,
        Rock = 1,
        Paper = 2,
        Scissor = 3,
    }

    enum GameResult
    {
        Loose = 0,
        Draw = 3,
        Win = 6,
    }
}
