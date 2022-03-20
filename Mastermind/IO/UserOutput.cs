using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Mastermind.IO.Interfaces;
using Mastermind.Model;

namespace Mastermind.IO
{
    public class UserOutput : IUserOutput
    {
        private readonly IConsoleIO _consoleIO;

        private const string Title = @"

███╗   ███╗ █████╗ ███████╗████████╗███████╗██████╗ ███╗   ███╗██╗███╗   ██╗██████╗ 
████╗ ████║██╔══██╗██╔════╝╚══██╔══╝██╔════╝██╔══██╗████╗ ████║██║████╗  ██║██╔══██╗
██╔████╔██║███████║███████╗   ██║   █████╗  ██████╔╝██╔████╔██║██║██╔██╗ ██║██║  ██║
██║╚██╔╝██║██╔══██║╚════██║   ██║   ██╔══╝  ██╔══██╗██║╚██╔╝██║██║██║╚██╗██║██║  ██║
██║ ╚═╝ ██║██║  ██║███████║   ██║   ███████╗██║  ██║██║ ╚═╝ ██║██║██║ ╚████║██████╔╝
╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚═════╝ 
                                                                                    

";

        public UserOutput(IConsoleIO consoleIO)
        {
            _consoleIO = consoleIO;
        }

        public void DisplayMenu()
        {
            _consoleIO.Clear();
            DisplayTitle();
            DisplayRules();
            DisplayValidColours();
        }

        public void DisplayCodeBreaker()
        {
            DisplayTitle();
            MakeBold("Code breaker\n");
            _consoleIO.WriteLine("*********");
            DisplayValidColours();
        }

        public void DisplayWin(Color[] solution)
        {
            DisplaySuccess("***Congratulations on cracking the code!");
            DisplaySolution(solution);
        }

        private void DisplaySolution(Color[] solution)
        {
            _consoleIO.WriteLine(MakeBold("The solution was: "));
            DisplayCirclesToConsole(solution);
            _consoleIO.WriteLine("\n");
        }

        public void DisplayNotMatchingResult(List<ResultColor> result)
        {
            _consoleIO.WriteLine("");
            if (result.Count == 0)
            {
                DisplayError("No matches found");
            }
            else
            {
                DisplayError("Your sequence doesn't quite match. Here's your hint\n");
                foreach (var resultColor in result)
                {
                    _consoleIO.Write(ConvertToEmoji(resultColor) + " ");
                }
            }

            _consoleIO.WriteLine("\nPress any key to continue ...");
            _consoleIO.ReadKey();
            _consoleIO.Clear();
        }

        public void DisplayMaxRoundsExceeded(Color[] solution)
        {
            DisplayTitle();
            DisplayError("You've reached the maximum allocated rounds, ending game.");
            _consoleIO.WriteLine("\nBetter luck next time ...\n\n");
            DisplaySolution(solution);
        }

        public void DisplayBoard(List<Attempt> attempts)
        {
            _consoleIO.WriteLine("Board");
            DisplayAttempts(attempts);
            _consoleIO.WriteLine("");
        }

        private void DisplayAttempts(List<Attempt> attempts)
        {
            for (var i = 0; i < attempts.Count; ++i)
            {
                _consoleIO.Write("Attempt #" + (i + 1));
                _consoleIO.Write("Guess: ");
                DisplayCirclesToConsole(attempts[i].Guess);
                _consoleIO.Write("   |   ");
                _consoleIO.Write("Hint: ");
                DisplayCirclesToConsole(attempts[i].Result);
                _consoleIO.WriteLine("");
            }
        }

        private void DisplayCirclesToConsole(List<ResultColor> colorsToPrint)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < colorsToPrint.Count; ++i)
            {
                switch (colorsToPrint[i])
                {
                    case ResultColor.Black:
                        sb.Append("⚫(B)");
                        break;
                    case ResultColor.White:
                        sb.Append("⚪(W)");
                        break;
                }

                if (i != colorsToPrint.Count - 1)
                {
                    sb.Append(", ");
                }
            }

            _consoleIO.Write(sb.ToString());
        }

        private void DisplayCirclesToConsole(Color[] colorsToPrint)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < colorsToPrint.Length; ++i)
            {
                switch (colorsToPrint[i])
                {
                    case Color.Red:
                        sb.Append("🔴(R)");
                        break;
                    case Color.Blue:
                        sb.Append("🔵(B)");
                        break;
                    case Color.Green:
                        sb.Append("🟢(G)");
                        break;
                    case Color.Orange:
                        sb.Append("🟠(O)");
                        break;
                    case Color.Purple:
                        sb.Append("🟣(P)");
                        break;
                    case Color.Yellow:
                        sb.Append("🟡(Y)");
                        break;
                }

                if (i != colorsToPrint.Length - 1)
                {
                    sb.Append(", ");
                }
            }

            _consoleIO.Write(sb.ToString());
        }

        private static string ConvertToEmoji(Color color)
        {
            return color switch
            {
                Color.Red => "🔴(R)",
                Color.Blue => "🔵(B)",
                Color.Green => "🟢(G)",
                Color.Orange => "🟠(O)",
                Color.Purple => "🟣(P)",
                Color.Yellow => "🟡(Y)",
                _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
            };
        }

        private static string ConvertToEmoji(ResultColor color)
        {
            return color switch
            {
                ResultColor.Black => "⚫(B)",
                ResultColor.White => "⚪(W)",
                _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
            };
        }

        public void PromptUserForColor()
        {
            _consoleIO.WriteLine("Please enter a valid colour [you can type the number or the colour]: ");
        }

        public void PromptUserForMaxRounds()
        {
            _consoleIO.WriteLine("Please enter the number of rounds you would like to play (Recommended: 8 - 12)");
        }

        public void Countdown()
        {
            var delay = 1000;
            var increment = 100;
            _consoleIO.WriteLine("Game starting in ");
            for (var i = 5; i > 0; --i)
            {
                _consoleIO.Write(i + "... ");
                Thread.Sleep(delay);
                delay += increment;
            }

            _consoleIO.Clear();
        }


        public void DisplayInvalidRounds()
        {
            DisplayError("Error: Invalid number of rounds, please enter a number greater than 0");
            _consoleIO.WriteLine("\n");
        }

        public void DisplayInvalidNumPegs()
        {
            DisplayError("Error: Invalid number of pegs, please try again.");
            _consoleIO.WriteLine("\n");
        }

        public void DisplayValidColorFromUser(Color color)
        {
            _consoleIO.WriteLine(ConvertToEmoji(color) + " accepted!");
        }

        public void DisplayInvalidColorFromUser()
        {
            DisplayError("Please enter a valid color or number.\n\n");
        }

        public void DisplayStatistics(List<Attempt> historyOfAttempts)
        {
            var count = 0;
            _consoleIO.WriteLine("\n");
            _consoleIO.WriteLine(MakeBold("Results and Statistics"));
            _consoleIO.WriteLine("Here's your list of attempts");

            foreach (var attempt in historyOfAttempts)
            {
                _consoleIO.Write("Attempt #" + (count + 1) + ": ");
                _consoleIO.Write("Guess: ");
                foreach (var color in attempt.Guess)
                {
                    _consoleIO.Write(ConvertToEmoji(color) + " ");
                }

                _consoleIO.Write("Hint: ");
                foreach (var resultColor in attempt.Result)
                {
                    _consoleIO.Write(ConvertToEmoji(resultColor) + " ");
                }

                _consoleIO.WriteLine("");
                count++;
            }
        }

        public void DisplayGameState(int maxRounds, int maxPegs)
        {
            DisplaySuccess("\nGame has been successfully initialized with " + maxRounds + " rounds and " +
                           maxPegs + " pegs.");
            _consoleIO.WriteLine("");
        }

        public void PromptUserForNumPegs()
        {
            _consoleIO.WriteLine(
                "Would you like to play with 4 or 6 pegs? (pegs are the total number of colours you need to guess)");
        }

        public void DisplayCurrentRound(int numRounds, int maxRounds)
        {
            ClearOutput();
            MakeBold("Round: ");
            DisplaySuccess(numRounds.ToString());
            _consoleIO.Write(" out of ");
            DisplayError(maxRounds.ToString());
            _consoleIO.WriteLine("");
        }

        private void DisplayTitle()
        {
            _consoleIO.WriteLine(Title);
        }

        private void DisplayRules()
        {
            _consoleIO.WriteLine(MakeBold("RULES ✔"));
            PrintLineBreak();
            _consoleIO.WriteLine(
                "Welcome to Mastermind! you need to guess the correct position and colour of the randomized board.\n");
            _consoleIO.Write("Hints will be given at the end of each round as a ");
            DisplayError("randomized");
            _consoleIO.WriteLine(" list of colours.");
            _consoleIO.WriteLine("- ⚫(Black) means a correct colour and position");
            _consoleIO.WriteLine("- ⚪(White) means a correct colour but incorrect position\n");
            _consoleIO.WriteLine(
                MakeItalicized("*Note: If your colour doesn't exist, no value will be added to the list of hints."));
            _consoleIO.WriteLine("\n");
        }

        private static string MakeItalicized(string s)
        {
            return "\x1b[3m" + s + "\x1b[0m";
        }

        private static string MakeBold(string s)
        {
            return "\x1b[1m" + s + "\x1b[0m";
        }

        private static void DisplayError(string s)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(s);
            Console.ResetColor();
        }

        private static void DisplaySuccess(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s);
            Console.ResetColor();
        }

        private void DisplayValidColours()
        {
            MakeBold("Valid colours/guesses are:\n");
            _consoleIO.WriteLine("🔴(1: Red)");
            _consoleIO.WriteLine("🔵(2: Blue)");
            _consoleIO.WriteLine("🟢(3: Green)");
            _consoleIO.WriteLine("🟠(4: Orange)");
            _consoleIO.WriteLine("🟣(5: Purple)");
            _consoleIO.WriteLine("🟡(6: Yellow)");
            _consoleIO.WriteLine("");
        }

        private void PrintLineBreak()
        {
            _consoleIO.WriteLine("");
            _consoleIO.WriteLine("----------");
            _consoleIO.WriteLine("");
        }

        private void ClearOutput()
        {
            _consoleIO.Clear();
        }
    }
}