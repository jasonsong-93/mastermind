using Mastermind.Input;
using Mastermind.Output;

namespace Mastermind
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
            var numRounds = 0;
            // Initialize handles the user input etc and stores the information of the game
            _gameState.Initialize(_userInput, _userOutput);
            var maxPegs = _gameState.NumCodePegs;
            var maxRounds = _gameState.MaxRounds;
            
            // Start the main game loop
            var gameFinished = false;
            // 1. Codemaker generates a solution
            var solution = _codeMaker.GenerateRandomSolutionCode(maxPegs);
            // 2. As long as the maxrounds hasn't been reached and the code hasn't been broken
            while (!gameFinished && (numRounds < maxRounds))
            {
                // 3. Keep breaking the code
                gameFinished = _codeBreaker.CodeBroken(solution);
                numRounds++;
            }
            // 4. Get the attempts the user has made so we can pass it into the game statistics class
            var guessHistory = _codeBreaker.Attempts;
            return new GameStatistics(guessHistory);
        }


    }
}