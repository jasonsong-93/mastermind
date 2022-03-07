namespace Mastermind.IO
{
    class UserOutput : IUserOutput
    {
        private readonly IConsoleIO _consoleIO;

        public UserOutput(IConsoleIO consoleIO)
        {
            _consoleIO = consoleIO;
        }

        public void DisplayIntroMessage()
        {
            _consoleIO.WriteLine("***WELCOME TO MASTERMIND!***");
        }

        public void DisplayFinished()
        {
            _consoleIO.WriteLine("AMAZING JOB");

        }

        public void DisplayIncorrect()
        {

            _consoleIO.WriteLine("WRONG");
        }
    }
}