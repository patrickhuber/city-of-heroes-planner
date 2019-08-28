using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CityOfInfo.Data.Mids.Tests
{
    public class EnhancementReaderTests
    {
        [Fact]
        public void CanReadEnhancement()
        {
            var enhancement = Fake.Create<Enhancement>();         
            new ReaderTest(
                setup: (writer) => 
                {
                    new EnhancementWriter(writer).Write(enhancement);
                }, 
                test: (reader) => 
                {
                    var record = new EnhancementReader(reader).Read();
                    Assert.Equal(enhancement, record);
                }).Run();
        }
    }
}
