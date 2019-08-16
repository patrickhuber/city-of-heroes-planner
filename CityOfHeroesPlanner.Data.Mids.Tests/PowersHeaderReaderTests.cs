using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CityOfHeroesPlanner.Data.Mids.Tests
{
    public class PowersHeaderReaderTests
    {
        [Fact]
        public void CanReadPowersHeader()
        {
            var powersHeader = new PowerHeader
            {
                Prefix = RecordHeaderGroupPrefixes.Powers,
                VersionData = new VersionData
                {
                    Revision = 1234,
                    RevisionDate = new DateTime(2019,02,02),
                    SourceFile = "test.csv",
                },
                LevelVersion = new VersionData
                {
                    Revision = 2345,
                    RevisionDate = new DateTime(2019, 02, 02),
                    SourceFile = "levels.csv",
                },
                EffectVersion = new VersionData
                {
                    Revision = 3456,
                    RevisionDate = new DateTime(2019, 02, 02),
                    SourceFile = "effects.csv",
                },
                InventionOriginAssignmentVersion = new VersionData
                {
                    Revision = 4567,
                    RevisionDate = new DateTime(2019, 02, 02),
                    SourceFile = "ios.csv",
                },
                Count = 2,
            };
            new ReaderTest(
                (writer)=> 
                {
                    var versionDataWriter = new VersionDataWriter(writer);                    
                    writer.Write(powersHeader.Prefix);
                    versionDataWriter.Write(powersHeader.VersionData);
                    versionDataWriter.Write(powersHeader.LevelVersion);
                    versionDataWriter.Write(powersHeader.EffectVersion);
                    versionDataWriter.Write(powersHeader.InventionOriginAssignmentVersion);
                    writer.Write(powersHeader.Count);
                }, 
                reader=> 
                {
                    var powersHeaderReader = new PowerHeaderReader(reader);
                    var headerRecord = powersHeaderReader.Read();
                    Assert.Equal(powersHeader, headerRecord);
                }).Run();
        }
    }
}
