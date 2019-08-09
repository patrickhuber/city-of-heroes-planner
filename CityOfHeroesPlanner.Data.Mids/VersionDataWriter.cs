using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class VersionDataWriter
    {
        private BinaryWriter _writer;

        public VersionDataWriter(BinaryWriter writer)
        {
            _writer = writer;
        }

        public void Write(VersionData versionData)
        {
            _writer.Write(versionData.Revision);
            _writer.Write(versionData.RevisionDate.ToBinary());
            _writer.Write(versionData.SourceFile);
        }
    }
}
