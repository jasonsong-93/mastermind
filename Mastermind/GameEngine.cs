namespace Mastermind
{
    public class GameEngine
    {
        private readonly IUserInput _userInput;
        private readonly ICodeBreaker _codeBreaker;
        private readonly ICodeMaker _codeMaker;

        public GameEngine(IUserInput userInput, ICodeBreaker codeBreaker, ICodeMaker codeMaker)
        {
            _userInput = userInput;
            _codeBreaker = codeBreaker;
            _codeMaker = codeMaker;
        }

        public GameStatistics Run()
        {
            var guessHistory = _codeBreaker.GetGuessHistory();
            return new GameStatistics(guessHistory);
        }
    }
}