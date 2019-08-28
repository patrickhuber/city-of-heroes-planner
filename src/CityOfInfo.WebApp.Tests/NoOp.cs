using System;
using Xunit;

namespace CityOfInfo.WebApp.Tests
{
    public class NoOp
    {
        [Fact]
        public void AlwaysGreen()
        {
            Assert.True(true);
        }
    }
}
