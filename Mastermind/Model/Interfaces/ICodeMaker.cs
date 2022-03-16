namespace Mastermind
{
    public interface ICodeMaker
    {
        Color[] GetSolutionCode(int numPegs);
    }
}