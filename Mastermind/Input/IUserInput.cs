namespace Mastermind.Input;

public interface IUserInput
{
    int BoardSize();
    int MaximumAttempts();
    int NumberOfColors();
    bool DuplicatesAllowed();
    bool SinglePlayerMode();
    Color[] PlayerGuess();
}