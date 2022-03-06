namespace Mastermind
{
    public interface ICodeMaker
    {
        Color[] GenerateRandomSolutionCode(int NumberOfPegs);
    }
}