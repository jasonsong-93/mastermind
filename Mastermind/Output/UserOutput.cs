namespace Mastermind.Output
{
    class UserOutput : IUserOutput
    {
        private readonly IConsoleOutput _consoleOutput;

        public UserOutput(IConsoleOutput consoleOutput)
        {
            _consoleOutput = consoleOutput;
        }
        public void PrintInitializationMessage()
        {
            _consoleOutput.WriteLine("");
        }
    }
}