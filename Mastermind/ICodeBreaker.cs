using System.Collections.Generic;

namespace Mastermind
{
    public interface ICodeBreaker
    {
        bool CodeBroken(Color[] solution, int numPegs);

        List<Attempt> Attempts { get; }
    }
}