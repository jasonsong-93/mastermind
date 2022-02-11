namespace Mastermind
{
    public class GameEngine
    {
        private readonly ICodeBreaker _codeBreaker;
        private readonly ICodeMaker _codeMaker;

        public GameEngine(ICodeBreaker codeBreaker, ICodeMaker codeMaker)
        {
            _codeBreaker = codeBreaker;
            _codeMaker = codeMaker;
        }

        public GameStatistics Run()
        {
            var gameFinished = false;
            var solution = _codeMaker.GetSolutionCode();
            while (!gameFinished)
            {
                if (!_codeBreaker.CodeBroken())
                {
                    _codeBreaker.CheckGuess(solution);
                }
                else
                {
                    gameFinished = true;
                }
            }
            var guessHistory = _codeBreaker.GetGuessHistory();
            return new GameStatistics(guessHistory);
        }
    }
}