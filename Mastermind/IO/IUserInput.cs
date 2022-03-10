namespace Mastermind.IO
{
    public interface IUserInput
    {
        Color[] PlayerGuess(int numPegs);
        int ValidateNumCodePegs();
        int GetValidMaxRounds();
    }
}