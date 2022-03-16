using Mastermind.IO;

namespace Mastermind
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