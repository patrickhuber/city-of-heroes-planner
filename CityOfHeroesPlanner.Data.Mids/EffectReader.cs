using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class EffectReader
    {
        private readonly BinaryReader _reader;

        public EffectReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public Effect Read()
        {
            Effect effect = new Effect();
            return effect;
        }
    }
}
