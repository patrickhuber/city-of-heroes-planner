using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CityOfHeroesPlanner.Data.Mids.Tests
{
    public class VersionDataReaderTests
    {
        [Fact]
        public void CanReadVersionData()
        {
            var versionData = new VersionData
            {
                Revision = 1234,
                RevisionDate = new DateTime(2019, 04, 20),
                SourceFile = "test.csv"
            };

            new ReaderTest(
                (writer) => 
                {
                    var versionDataWriter = new VersionDataWriter(writer);
                    versionDataWriter.Write(versionData);
                },
                (reader) => 
                {
                    var versionDataReader = new VersionDataReader(reader);
                    var header = versionDataReader.Read();
                    Assert.Equal(versionData, header);
                }).Run();
        }
    }
}
