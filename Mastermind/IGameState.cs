using Mastermind.Input;

namespace Mastermind
{
    public interface IGameState
    {
        void Initialize(IUserInput userInput, IUserOutput userOutput);
        int MaxCodePegs { get; set; }
        int MaxRounds { get; set; }
    }
}