using Mastermind.Input;
using Mastermind.Output;

namespace Mastermind
{
    public class GameState : IGameState
    {
        public int NumCodePegs { get; set; }

        public int MaxRounds { get; set; }
        public void Initialize(IUserInput userInput, IUserOutput userOutput)
        {
            MaxRounds = userInput.ValidateMaxRounds();
            NumCodePegs = userInput.ValidateNumCodePegs();
        }

    }
}