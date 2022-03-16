using System.Collections.Generic;

namespace Mastermind.Model.Interfaces
{
    public interface ICodeBreaker
    {
        bool CodeBroken(Color[] solution, int numPegs);

        List<Attempt> Attempts { get; }
    }
}