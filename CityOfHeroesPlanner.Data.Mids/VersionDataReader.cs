using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class VersionDataReader
    {
        private BinaryReader _reader;

        public VersionDataReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public VersionData Read()
        {
            var versionData = new VersionData();
            versionData.Revision = _reader.ReadInt32();
            versionData.RevisionDate = DateTime.FromBinary(_reader.ReadInt64());
            versionData.SourceFile = _reader.ReadString();
            return versionData;
        }
    }
}
