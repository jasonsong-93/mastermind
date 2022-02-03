namespace Mastermind.Tests
{
    public interface IGameSetup
    {
        int GetBoardSize();
        Color[] GetSolution();
        int GetMaximumAttempts();
        int GetNumberOfColors();
        bool DuplicatesAllowed();
        bool SinglePlayerMode();
    }
}