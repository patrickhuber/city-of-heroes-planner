using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CityOfHeroesPlanner.Data.Mids.Tests
{
    public class RecordHeaderReaderTests
    {
        [Fact]
        public void CanReadArchetypeHeader()
        {
            CanReadRecordHeader(RecordHeaderGroupPrefixes.Archetypes);
        }

        [Fact]
        public void CanReadPowersetHeader()
        {
            CanReadRecordHeader(RecordHeaderGroupPrefixes.Powersets);
        }
                
        public void CanReadRecordHeader(string prefix)
        {
            using (var memoryStream = new MemoryStream())
            {
                var beginText = prefix;
                var versionData = new VersionData
                {
                    Revision = 1234,
                    RevisionDate = new DateTime(2019, 04, 20),
                    SourceFile = "test.csv"
                };
                var recordHeader = new RecordHeader
                {
                    VersionData = versionData,
                    Count = 2,
                    Prefix = RecordHeaderGroupPrefixes.Archetypes,
                };

                using (var binaryWriter = new BinaryWriter(memoryStream, Encoding.Default, true))
                {
                    binaryWriter.Write(beginText);
                    binaryWriter.Write(recordHeader.VersionData.Revision);
                    binaryWriter.Write(recordHeader.VersionData.RevisionDate.ToBinary());
                    binaryWriter.Write(recordHeader.VersionData.SourceFile);
                    binaryWriter.Write(recordHeader.Count);
                }

                memoryStream.Seek(0, SeekOrigin.Begin);

                using (var binaryReader = new BinaryReader(memoryStream, Encoding.Default, true))
                {
                    var reader = new RecordHeaderReader(binaryReader);
                    var header = reader.Read();
                    Assert.Equal(beginText, header.Prefix);
                    Assert.Equal(versionData, header.VersionData);
                }
            }
        }
    }
}
