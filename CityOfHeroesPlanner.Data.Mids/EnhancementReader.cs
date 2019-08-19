using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class EnhancementReader
    {
        private BinaryReader _reader;

        public EnhancementReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public Enhancement Read()
        {
            var enhancement = new Enhancement();
            return enhancement;
        }
    }
}
