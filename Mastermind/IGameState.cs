using Mastermind.Input;
using Mastermind.Output;

namespace Mastermind
{
    public interface IGameState
    {
        void Initialize(IUserInput userInput, IUserOutput userOutput);
        int NumCodePegs { get; set; }
        int MaxRounds { get; set; }
    }
}