using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class NamedEntityReader
    {
        private BinaryReader _reader;

        public NamedEntityReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public NamedEntity Read()
        {
            var entity = new NamedEntity();
            entity.Name = _reader.ReadString();
            entity.Id = _reader.ReadInt32();            
            return entity;
        }
    }
}
