using System.Collections.Generic;

namespace Mastermind
{
    public interface ICodeBreaker
    {
        bool CodeBroken(Color[] solution);

        List<Attempt> Attempts
        {
            get;
            set;
        }
    }
}