using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class BuildReader
    {
        private readonly BinaryReader reader;        

        public BuildReader(BinaryReader reader)
        {
            this.reader = reader;
        }

        public Build Read()
        {
            return new Build();
        }
    }
}
