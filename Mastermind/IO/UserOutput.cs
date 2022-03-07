using System.Collections.Generic;

namespace Mastermind.IO
{
    class UserOutput : IUserOutput
    {
        private readonly IConsoleIO _consoleIO;

        private readonly string title = @"
'##::::'##::::'###:::::'######::'########:'########:'########::'##::::'##:'####:'##::: ##:'########::
 ###::'###:::'## ##:::'##... ##:... ##..:: ##.....:: ##.... ##: ###::'###:. ##:: ###:: ##: ##.... ##:
 ####'####::'##:. ##:: ##:::..::::: ##:::: ##::::::: ##:::: ##: ####'####:: ##:: ####: ##: ##:::: ##:
 ## ### ##:'##:::. ##:. ######::::: ##:::: ######::: ########:: ## ### ##:: ##:: ## ## ##: ##:::: ##:
 ##. #: ##: #########::..... ##:::: ##:::: ##...:::: ##.. ##::: ##. #: ##:: ##:: ##. ####: ##:::: ##:
 ##:.:: ##: ##.... ##:'##::: ##:::: ##:::: ##::::::: ##::. ##:: ##:.:: ##:: ##:: ##:. ###: ##:::: ##:
 ##:::: ##: ##:::: ##:. ######::::: ##:::: ########: ##:::. ##: ##:::: ##:'####: ##::. ##: ########::
..:::::..::..:::::..:::......::::::..:::::........::..:::::..::..:::::..::....::..::::..::........:::
";

        public UserOutput(IConsoleIO consoleIO)
        {
            _consoleIO = consoleIO;
        }

        public void DisplayIntroMessage()
        {
            _consoleIO.WriteLine(title);
        }

        public void DisplayFinished()
        {
            _consoleIO.WriteLine("***Congratulations on cracking the code! Here are your results***");
        }

        public void DisplayIncorrect()
        {
            _consoleIO.WriteLine("Please try again");
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
    }
}