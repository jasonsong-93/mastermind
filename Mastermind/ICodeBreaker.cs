using System.Collections.Generic;

namespace Mastermind
{
    public interface ICodeBreaker
    {
        List<Attempt> GetGuessHistory();
        bool RunOneCheck();
    }
}