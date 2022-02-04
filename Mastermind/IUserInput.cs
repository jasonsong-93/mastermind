namespace Mastermind
{
    public interface IUserInput
    {
        int BoardSize();
        int MaximumAttempts();
        int NumberOfColors();
        bool DuplicatesAllowed();
        bool SinglePlayerMode();
        int GetBoardSize();
        int GetMaximumAttempts();
        int GetNumberOfColors();
        Color[] GetSolution();
    }
}