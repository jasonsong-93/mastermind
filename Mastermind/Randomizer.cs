using System;

namespace Mastermind
{
    internal class Randomizer : IRandomizer
    {
        private readonly Random _rand = new();

        public int GenerateRandomInt(int maxRange)
        {
            return _rand.Next(maxRange);
        }
    }
}