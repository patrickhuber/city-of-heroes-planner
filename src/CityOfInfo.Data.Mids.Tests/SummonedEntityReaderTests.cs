using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CityOfInfo.Data.Mids.Tests
{
    public class SummonedEntityReaderTests
    {
        [Fact]
        public void CanReadSummonedEntity()
        {
            var summonedEntity = Fake.Create<SummonedEntity>();

            new ReaderTest(
                setup: (writer)=> 
                {
                    new SummonedEntityWriter(writer)
                        .Write(summonedEntity);
                }, 
                test: (reader)=> 
                {
                    var record = new SummonedEntityReader(reader).Read();                     
                    Assert.Equal(summonedEntity, record);
                }).Run();
            
        }
    }
}
