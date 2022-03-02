using System.Reflection.Metadata;
using Mastermind.Input;

namespace Mastermind
{
    class GameState : IGameState
    {
        public int MaxCodePegs { get; set; }
        public int MaxRounds { get; set; }

        public void Initialize(IUserInput userInput, IUserOutput userOutput)
        {
            userOutput.PrintInitializationMessage();
        }
      
    }
    
}