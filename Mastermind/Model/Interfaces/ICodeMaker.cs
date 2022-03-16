namespace Mastermind.Model.Interfaces
{
    public interface ICodeMaker
    {
        Color[] GetSolutionCode(int numPegs);
    }
}