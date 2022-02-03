namespace Mastermind.Tests
{
    public interface IGameSetup
    {
        int GetBoardSize();
        Color[] GetSolution();
    }
}