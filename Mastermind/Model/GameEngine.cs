using Mastermind.IO.Interfaces;
using Mastermind.Model.Interfaces;

namespace Mastermind.Model
{
    public class GameEngine
    {
        private readonly ICodeBreaker _codeBreaker;
        private readonly ICodeMaker _codeMaker;
        private readonly IUserInput _userInput;
        private readonly IUserOutput _userOutput;
        private readonly IGameState _gameState;

        public GameEngine(ICodeBreaker codeBreaker, ICodeMaker codeMaker, IUserInput userInput, IUserOutput userOutput,
            IGameState gameState)
        {
            _codeBreaker = codeBreaker;
            _codeMaker = codeMaker;
            _userInput = userInput;
            _userOutput = userOutput;
            _gameState = gameState;
        }

        public GameStatistics Run()
        {
            var codeSuccessfullyBroken = false;
            var numRounds = 1;

            _userOutput.DisplayMenu();
            _gameState.Initialize(_userInput);
            var maxPegs = _gameState.NumCodePegs;
            var maxRounds = _gameState.MaxRounds;

            _userOutput.DisplayGameState(maxRounds, maxPegs);
            _userOutput.Countdown();

            var solution = _codeMaker.GetSolutionCode(maxPegs);
            while (!codeSuccessfullyBroken && numRounds <= maxRounds)
            {
                _userOutput.DisplayCurrentRound(numRounds, maxRounds);
                codeSuccessfullyBroken = _codeBreaker.CodeBroken(solution, maxPegs);
                if (codeSuccessfullyBroken)
                {
                    _userOutput.DisplayWin(solution);
                }

                numRounds++;
                if (numRounds > maxRounds && !codeSuccessfullyBroken)
                {
                    _userOutput.DisplayMaxRoundsExceeded(solution);
                }
            }

            var guessHistory = _codeBreaker.Attempts;
            return new GameStatistics(guessHistory, _userOutput);
        }
    }
}