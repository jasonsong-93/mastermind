namespace Mastermind.IO
{
    public interface IUserInput
    {
        Color[] PlayerGuess();
        int ValidateNumCodePegs();
        int GetValidMaxRounds();
    }
}