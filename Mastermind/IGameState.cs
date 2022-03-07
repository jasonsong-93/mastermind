using Mastermind.IO;

namespace Mastermind
{
    public interface IGameState
    {
        int NumCodePegs { get; set; }
        int MaxRounds { get; set; }
        void Initialize(IUserInput userInput,  IUserOutput userOutput);
    }
}