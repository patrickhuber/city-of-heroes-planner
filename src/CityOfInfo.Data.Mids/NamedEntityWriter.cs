using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class NamedEntityWriter
    {
        private BinaryWriter _writer;

        public NamedEntityWriter(BinaryWriter writer)
        {
            _writer = writer;
        }

        public void Write(NamedEntity entity)
        {
            _writer.Write(entity.Name);
            _writer.Write(entity.Id);
        }
    }
}
