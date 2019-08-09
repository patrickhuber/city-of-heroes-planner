using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class Issue12Reader
    {
        private BinaryReader _reader;

        public Issue12Reader(BinaryReader reader)
        {
            _reader = reader;
        }        
    }
}
