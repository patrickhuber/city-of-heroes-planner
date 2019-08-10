using System;
using System.IO;

namespace CityOfHeroesPlanner.Data.Mids.Tests
{
    internal class EffectWriter
    {
        private BinaryWriter _writer;

        public EffectWriter(BinaryWriter writer)
        {
            _writer = writer;
        }

        internal void Write(Effect effect)
        {
            throw new NotImplementedException();
        }
    }
}