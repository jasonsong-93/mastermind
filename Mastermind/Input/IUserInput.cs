namespace Mastermind.Input
{
    public interface IUserInput
    {
        Color[] PlayerGuess();
        int ValidateNumCodePegs();
        int ValidateMaxRounds();
    }
}