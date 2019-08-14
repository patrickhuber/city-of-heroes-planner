using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CityOfHeroesPlanner.Data.Mids.Tests
{
    public class HexUtilTests
    {
        [Fact]
        public void CanHexDecode()
        {
            var input = Encoding.ASCII.GetBytes("42556D79");
            var output = HexUtil.Decode(input);
            var expected = new byte[]
            {
                66,
                85,
                109,
                121,
            };
            Assert.Equal(expected.Length, output.Length);
            for (var i = 0; i < expected.Length; i++)
                Assert.Equal(expected[i], output[i]);
        }

    }
}
