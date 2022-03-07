using Mastermind.IO;

namespace Mastermind
{
    public class GameState : IGameState
    {
        public int NumCodePegs { get; set; }

        public int MaxRounds { get; set; }

        public void Initialize(IUserInput userInput)
        {
            MaxRounds = userInput.GetValidMaxRounds();
            NumCodePegs = userInput.ValidateNumCodePegs();
        }
    }
}