using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CityOfInfo.Data.Mids.Tests
{
    public class EnhancementSetReaderTests
    {
        [Fact]
        public void CanReadEnhancementSet()
        {
            var enhancementSet = Fake.Create<EnhancementSet>();
            new ReaderTest(
                setup: (writer) =>
                {
                    new EnhancementSetWriter(writer).Write(enhancementSet);
                }, 
                test: (reader) => 
                {
                    var record = new EnhancementSetReader(reader).Read();
                    Assert.Equal(enhancementSet, record);
                })
                .Run();
        }
    }
}
