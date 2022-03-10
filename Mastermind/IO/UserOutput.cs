using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Mastermind.IO
{
    public class UserOutput : IUserOutput
    {
        private readonly IConsoleIO _consoleIO;

        private readonly string title = @"

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

        public void DisplayFinished()
        {
            DisplaySuccess("***Congratulations on cracking the code! Here are your results***");
        }

        public void DisplayResult(List<ResultColor> result)
        {
            foreach (var color in result)
            {
                _consoleIO.Write(color + " ");
            }
        }

        public void DisplayMaxRoundsExceeded()
        {
            _consoleIO.WriteLine("You've reached the maximum allocated rounds, ending game.");
        }


        public void DisplayBoard(List<Attempt> attempts)
        {
            DisplayAttempts(attempts);
        }

        private void DisplayAttempts(List<Attempt> attempts)
        {
            PrintLineBreak();
            _consoleIO.WriteLine("Board");
            for (var i = 0; i < attempts.Count; ++i)
            {
                _consoleIO.Write("Attempt #" + (i + 1));
                _consoleIO.Write("Guess: ");
                DisplayCirclesToConsole(attempts[i].Guess);
                _consoleIO.Write( "   |   ");
                _consoleIO.Write("Hint: ");
                DisplayCirclesToConsole(attempts[i].Result);
                _consoleIO.WriteLine("");
            }
            _consoleIO.WriteLine("");
        }
        
        private void DisplayCirclesToConsole(List<ResultColor> colorsToPrint)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < colorsToPrint.Count; ++i)
            {
                switch (colorsToPrint[i])
                {
                    case ResultColor.Black:
                        sb.Append("⚫(Black)");
                        break;
                    case ResultColor.White:
                        sb.Append("⚪(White)");
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
                        sb.Append("🔴(Red)");
                        break;
                    case Color.Blue:
                        sb.Append("🔵(Blue)");
                        break;
                    case Color.Green:
                        sb.Append("🟢(Green)");
                        break;
                    case Color.Orange:
                        sb.Append("🟠(Orange)");
                        break;
                    case Color.Purple:
                        sb.Append("🟣(Purple)");
                        break;
                    case Color.Yellow:
                        sb.Append("🟡(Yellow)");
                        break;
                }
                if (i != colorsToPrint.Length - 1)
                {
                    sb.Append(", ");
                }
            }
            _consoleIO.Write(sb.ToString());
        }

        public void PromptUserForColor()
        {
            _consoleIO.WriteLine("Please enter a valid color: ");
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

        public void ClearOutput()
        {
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

        public void DisplayGameState(int maxRounds, int maxPegs)
        {
            DisplaySuccess("\nGame has been successfully initialized with " + maxRounds + " number of rounds and " +
                           maxPegs + " number of pegs.");
            _consoleIO.WriteLine("");
        }

        public void PromptUserForNumPegs()
        {
            _consoleIO.WriteLine(
                "Would you like to play with 4 or 6 pegs? (pegs are the total number of colours you need to guess)");
        }

        public void DisplayCurrentRound(int numRounds, int maxRounds)
        {
            MakeBold("Round: ");
            DisplaySuccess(numRounds.ToString());
            _consoleIO.Write(" out of ");
            DisplayError(maxRounds.ToString());
            _consoleIO.WriteLine("");
        }

        private void DisplayTitle()
        {
            _consoleIO.WriteLine(title);
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
            _consoleIO.WriteLine(MakeItalicized("*Note: If your colour doesn't exist, no value will be added to the list of hints."));
            _consoleIO.WriteLine("\n");
        }

        private void MakeBordered(string s)
        {
            
        }

        private string MakeItalicized(string s)
        {
            return "\x1b[3m" + s + "\x1b[0m";
        }

        private string MakeBold(string s)
        {
            return "\x1b[1m" + s + "\x1b[0m";
        }

        private void DisplayError(string s)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(s);
            Console.ResetColor();
        }

        private void DisplaySuccess(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s);
            Console.ResetColor();
        }

        private void DisplayValidColours()
        {
            MakeBold("Valid colours/guesses are:\n");
            _consoleIO.WriteLine("🔴(Red)");
            _consoleIO.WriteLine("🔵(Blue)");
            _consoleIO.WriteLine("🟢(Green)");
            _consoleIO.WriteLine("🟠(Orange)");
            _consoleIO.WriteLine("🟣(Purple)");
            _consoleIO.WriteLine("🟡(Yellow)");
            _consoleIO.WriteLine("");
        }

        private void PrintLineBreak()
        {
            _consoleIO.WriteLine("");
            _consoleIO.WriteLine("----------");
            _consoleIO.WriteLine("");
        }
    }
}