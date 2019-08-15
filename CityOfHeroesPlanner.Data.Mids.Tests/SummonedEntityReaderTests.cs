using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CityOfHeroesPlanner.Data.Mids.Tests
{
    public class SummonedEntityReaderTests
    {
        [Fact]
        public void CanReadSummonedEntity()
        {
            var summonedEntity = new SummonedEntity
            {
                ID = "ID",
                DisplayName = "DisplayName",
                EntityType = 10,
                ClassName = "ClassName",
                PowerSetFullNames = new [] { "PowerSetFullName" },
                UpgradePowerFullNames = new [] { "UpgradePowerSetFullName" },
            };

            new ReaderTest(
                setup: (writer)=> 
                {
                    new SummonedEntityWriter(writer)
                    .Write(summonedEntity);
                }, 
                test: (reader)=> 
                {
                    var summonedEntityReader = new SummonedEntityReader(reader);
                    var record = summonedEntityReader.Read();
                    Assert.Equal(summonedEntity, record);
                }).Run();
            
        }
    }
}
