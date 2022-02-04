namespace Mastermind
{
    public class GameEngine
    {
        private readonly IUserInput _userInput;
        private readonly ICodeBreaker _codeBreaker;

        public GameEngine(IUserInput userInput, ICodeBreaker codeBreaker)
        {
            _userInput = userInput;
            _codeBreaker = codeBreaker;
        }

        public GameStatistics Run()
        {
            var guessHistory = _codeBreaker.GetGuessHistory();
            return new GameStatistics(guessHistory);
        }
    }
}