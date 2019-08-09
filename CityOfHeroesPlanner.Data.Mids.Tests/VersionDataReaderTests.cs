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
            using (var memoryStream = new MemoryStream())
            {                
                var revision = 1234;
                var revisionDate = new DateTime(2019, 04, 20);
                var file = "test.csv";

                using (var binaryWriter = new BinaryWriter(memoryStream, Encoding.Default, true))
                {                    
                    binaryWriter.Write(revision);
                    binaryWriter.Write(revisionDate.ToBinary());
                    binaryWriter.Write(file);                    
                }

                memoryStream.Seek(0, SeekOrigin.Begin);

                using (var binaryReader = new BinaryReader(memoryStream, Encoding.Default, true))
                {
                    var reader = new VersionDataReader(binaryReader);
                    var header = reader.Read();                    
                    Assert.Equal(revision, header.Revision);
                    Assert.Equal(revisionDate, header.RevisionDate);
                    Assert.Equal(file, header.SourceFile);
                }
            }
        }
    }
}
