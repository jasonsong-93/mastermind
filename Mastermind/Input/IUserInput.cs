namespace Mastermind.Input
{
    public interface IUserInput
    {
        Color[] PlayerGuess();
        int MaxCodePegs();
        // Type of game
        int MaxTurns();
    }
}