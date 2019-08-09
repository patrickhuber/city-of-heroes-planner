using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class RecordHeaderReader
    {
        private BinaryReader _reader;

        public RecordHeaderReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public RecordHeader Read()
        {
            var header = new RecordHeader();
            header.Prefix = _reader.ReadString();            
            var versionDataReader = new VersionDataReader(_reader);
            header.VersionData = versionDataReader.Read();
            header.Count = _reader.ReadInt32();
            return header;
        }
    }
}
