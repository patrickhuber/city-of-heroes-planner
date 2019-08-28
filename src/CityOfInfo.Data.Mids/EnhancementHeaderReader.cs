using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class EnhancementHeaderReader
    {
        private BinaryReader _reader;

        public EnhancementHeaderReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public EnhancementHeader Read()
        {
            var header = new EnhancementHeader();
            header.Prefix = _reader.ReadString();
            header.Version = _reader.ReadSingle();
            header.Count = _reader.ReadInt32();
            return header;
        }
    }
}
