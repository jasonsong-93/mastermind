using System;

namespace Mastermind
{
    public class Randomizer : IRandomizer
    {
        private readonly Random _rand;

        public Randomizer(Random rand)
        {
            _rand = rand;
        }

        public int GenerateRandomInt(int maxRange)
        {
            return _rand.Next(maxRange);
        }
    }
}