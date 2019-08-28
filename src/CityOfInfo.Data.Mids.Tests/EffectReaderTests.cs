using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CityOfInfo.Data.Mids.Tests
{
    public class EffectReaderTests
    {
        [Fact]
        public void CanReadEffect()
        {
            var effect = Fake.Create<Effect>();
            new ReaderTest(setup: (writer) =>
            {
                new EffectWriter(writer).Write(effect);
            },
            test: (reader) =>
            {
                var record = new EffectReader(reader).Read();
                Assert.Equal(effect, record);
            }).Run();
        }
    }
}
