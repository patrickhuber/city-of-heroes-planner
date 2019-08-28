using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CityOfInfo.Data.Mids.Tests
{
    public class EnhancementHeaderReaderTests
    {
        [Fact]
        public void CanReadEnhancementHeader()
        {
            var header = Fake.Create<EnhancementHeader>();
            new ReaderTest(
                setup: (writer) =>
                {
                    new EnhancementHeaderWriter(writer).Write(header);
                },
                test: (reader) =>
                {
                    var record = new EnhancementHeaderReader(reader).Read();
                    Assert.Equal(header, record);
                }).Run();
        }
    }
}
