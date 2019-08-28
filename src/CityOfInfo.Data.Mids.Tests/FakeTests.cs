using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CityOfInfo.Data.Mids.Tests
{
    public class FakeTests
    {
        [Fact]
        public void CanGenerateInt()
        {
            var value = Fake.Create<int>();
            Assert.Equal(0, value);
        }

        [Fact]
        public void CanGenerateString()
        {
            var value = Fake.Create<string>();
            Assert.Equal(string.Empty, value);
        }

        [Fact]
        public void CanGenerateFloat()
        {
            var value = Fake.Create<float>();
            Assert.Equal(0f, value);
        }

        [Fact]
        public void CanGenerateBoolean()
        {
            var value = Fake.Create<bool>();
            Assert.False(value);
        }

        [Fact]
        public void CanGenerateEffect()
        {
            var value = Fake.Create<Effect>();
            Assert.Equal(14, value.Aspect);
            Assert.Equal("MagnitudeExpression", value.MagnitudeExpression);
            Assert.Equal(3f, value.Magnitude);
            Assert.False(value.IgnoreEnhancementDiversification);
        }

        [Fact]
        public void CanGenerateChildProperty()
        {
            var value = Fake.Create<EnhancementEffect>();
            Assert.NotNull(value.Effect);
            Assert.NotEqual(0, value.Effect.Aspect);
        }

        [Fact]
        public void CanGenerateArrayProperty()
        {
            var value = Fake.Create<Requirement>();
            Assert.NotNull(value.ClassNames);
            Assert.Equal(2, value.ClassNames.Length);
            Assert.Equal("0", value.ClassNames[0]);
            Assert.Equal("1", value.ClassNames[1]);
        }
    }
}
