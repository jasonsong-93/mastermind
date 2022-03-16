using Mastermind.Model;

namespace Mastermind.IO.Interfaces
{
    public interface IUserInput
    {
        Color[] PlayerGuess(int numPegs);
        int ValidateNumCodePegs();
        int GetValidMaxRounds();
    }
}