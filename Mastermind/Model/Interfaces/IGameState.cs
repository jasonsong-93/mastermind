using Mastermind.IO.Interfaces;

namespace Mastermind.Model.Interfaces
{
    public interface IGameState
    {
        int NumCodePegs { get; }
        int MaxRounds { get; }
        void Initialize(IUserInput userInput);
    }
}