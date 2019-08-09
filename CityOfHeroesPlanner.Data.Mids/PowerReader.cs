using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class PowerReader
    {
        private readonly BinaryReader _reader;

        public PowerReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public Power Read()
        {
            var power = new Power();
            return power;
        }
    }
}
