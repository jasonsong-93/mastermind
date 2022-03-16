using Mastermind.IO;

namespace Mastermind
{
    public interface IGameState
    {
        int NumCodePegs { get; }
        int MaxRounds { get; }
        void Initialize(IUserInput userInput);
    }
}