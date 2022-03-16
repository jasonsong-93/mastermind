using System;
using Mastermind.Model.Interfaces;

namespace Mastermind.Model
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