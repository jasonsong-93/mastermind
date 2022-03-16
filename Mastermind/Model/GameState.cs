using Mastermind.IO.Interfaces;
using Mastermind.Model.Interfaces;

namespace Mastermind.Model
{
    public class GameState : IGameState
    {
        public int NumCodePegs { get; private set; }

        public int MaxRounds { get; private set; }

        public void Initialize(IUserInput userInput)
        {
            MaxRounds = userInput.GetValidMaxRounds();
            NumCodePegs = userInput.ValidateNumCodePegs();
        }
    }
}