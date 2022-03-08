using System;
using System.Collections.Generic;

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



        public void DisplayFinished()
        {
            _consoleIO.WriteLine("***Congratulations on cracking the code! Here are your results***");
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

        public void DisplayAttempts(List<Attempt> attempts)
        {
            foreach (var t in attempts)
            {
                foreach (var color in t.Guess)
                {
                    _consoleIO.Write(color + " ");
                }
            }
            _consoleIO.WriteLine("");
        }

        public void DisplayCodeBreaker()
        {
            _consoleIO.Write(title);
        }

        public void PromptUserForColor()
        {
            _consoleIO.WriteLine("Please enter a valid color: ");
        }

        public void PromptUserForMaxRounds()
        {
            _consoleIO.WriteLine("Please enter the number of rounds you would like to play (Recommended: 8 - 12)");
        }
        private void DisplayTitle()
        {
            _consoleIO.WriteLine(title);
        }
        private void DisplayRules()
        {
            _consoleIO.WriteLine("RULES ✔");
            _consoleIO.WriteLine("----------");
            _consoleIO.WriteLine("Welcome to Mastermind! you need to guess the correct position and colour of the randomized board.");
            _consoleIO.WriteLine("");
            _consoleIO.Write("Hints will be given at the end of each round as a ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            _consoleIO.Write("\x1b[1mrandomized\x1b[0m");
            Console.ResetColor();
            _consoleIO.WriteLine(" list of colours.");
            _consoleIO.WriteLine("- ⚫(Black) means a correct colour and position");
            _consoleIO.WriteLine("- ⚪(White) means a correct colour, but incorrect position");
            _consoleIO.WriteLine("If your colour doesn't exist, no value will be added to the list of hints.");
            _consoleIO.WriteLine("");

        }
        
        private void DisplayValidColours()
        {
            _consoleIO.WriteLine("Valid colours/guesses are:");
            _consoleIO.WriteLine("🔴(Red)");
            _consoleIO.WriteLine("🔵(Blue)");
            _consoleIO.WriteLine("🟢(Green)");
            _consoleIO.WriteLine("🟠(Orange)");
            _consoleIO.WriteLine("🟣(Purple)");
            _consoleIO.WriteLine("🟡(Yellow)");
            _consoleIO.WriteLine("");
        }
    }
}