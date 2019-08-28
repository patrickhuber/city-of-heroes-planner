using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CityOfInfo.Data.Mids.Tests
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
            var recordHeader = Fake.Create<RecordHeader>();
            new ReaderTest(
                setup: (writer) => 
                {
                    writer.Write(recordHeader.Prefix);
                    writer.Write(recordHeader.VersionData.Revision);
                    writer.Write(recordHeader.VersionData.RevisionDate.ToBinary());
                    writer.Write(recordHeader.VersionData.SourceFile);
                    writer.Write(recordHeader.Count);
                }, 
                test: (reader) => 
                {
                    var header = new RecordHeaderReader(reader).Read();
                    Assert.Equal(recordHeader, header);
                }).Run();
        }
    }
}
