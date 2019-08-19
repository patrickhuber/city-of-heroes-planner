using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CityOfHeroesPlanner.Data.Mids.Tests
{
    public class EnhancementHeaderReaderTests
    {
        [Fact]
        public void CanReadEnhancementHeader()
        {
            var header = new EnhancementHeader
            {
                Prefix = "Prefix",
                Count = 10,
                Version = 1.0f,
            };
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
