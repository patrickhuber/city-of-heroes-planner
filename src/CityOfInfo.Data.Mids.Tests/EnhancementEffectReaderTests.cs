using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CityOfInfo.Data.Mids.Tests
{
    public class EnhancementEffectReaderTests
    {
        [Fact]
        public void CanReadEnhancemenEffect()
        {
            var enhancementEffect = Fake.Create<EnhancementEffect>();
            new ReaderTest(
                setup: (writer) => 
                {
                    new EnhancementEffectWriter(writer).Write(enhancementEffect);
                }, 
                test: (reader) => 
                {
                    var record = new EnhancementEffectReader(reader).Read();
                    Assert.Equal(enhancementEffect, record);
                })
                .Run();
        }
    }
}
