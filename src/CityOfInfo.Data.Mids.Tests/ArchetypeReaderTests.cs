using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CityOfInfo.Data.Mids.Tests
{
    public class ArchetypeReaderTests
    {
        [Fact]
        public void CanReadArchetype()
        {
            var archetype = Fake.Create<Archetype>();
            new ReaderTest(
                setup: (writer) => 
                {
                    new ArchetypeWriter(writer).Write(archetype);
                }, 
                test: (reader) => 
                {
                    var archetypeReader = new ArchetypeReader(reader);
                    var record = archetypeReader.Read();
                    Assert.Equal(archetype, record);
                }
            ).Run();
        }
    }
}
