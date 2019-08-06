using System;
using Xunit;

namespace CityOfHeroesPlanner.WebApp.Tests
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
