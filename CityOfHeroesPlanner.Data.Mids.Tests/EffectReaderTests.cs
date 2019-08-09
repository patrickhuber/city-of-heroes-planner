using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CityOfHeroesPlanner.Data.Mids.Tests
{
    public class EffectReaderTests
    {
        [Fact]
        public void CanReadEffect()
        {
            var effect = new Effect { };
            new ReaderTest(setup: (writer) => 
            {

            }, 
            test: (reader) => 
            {

            }).Run();
        }
    }
}
