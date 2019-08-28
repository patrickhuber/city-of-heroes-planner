using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CityOfInfo.Data.Mids.Tests
{
    public class VersionDataReaderTests
    {
        [Fact]
        public void CanReadVersionData()
        {
            var versionData = Fake.Create<VersionData>();

            new ReaderTest(
                (writer) => 
                {
                    new VersionDataWriter(writer)
                    .Write(versionData);
                },
                (reader) => 
                {                    
                    var header = new VersionDataReader(reader).Read();
                    Assert.Equal(versionData, header);
                }).Run();
        }
    }
}
