using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CityOfInfo.Data.Mids.Tests
{
    public class NamedEntityTests
    {
        [Fact]
        public void CanReadNamedEntity()
        {
            var namedEntity = Fake.Create<NamedEntity>();
            new ReaderTest(
                setup: (writer) => 
                {
                    new NamedEntityWriter(writer).Write(namedEntity);
                },
                test: (reader) => 
                {
                    var record = new NamedEntityReader(reader).Read();
                    Assert.Equal(namedEntity, record);
                }).Run();
        }
    }
}
