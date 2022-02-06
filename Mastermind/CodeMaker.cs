namespace Mastermind.Tests
{
    public class CodeMaker : ICodeMaker
    {
        private readonly IRandomizer _randomizer;

        public CodeMaker(IRandomizer randomizer)
        {
            _randomizer = randomizer;
            throw new System.NotImplementedException();
        }

        public Color[] GetSolutionCode()
        {
            throw new System.NotImplementedException();
        }
    }
}