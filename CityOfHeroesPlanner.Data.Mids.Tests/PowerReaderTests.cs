using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CityOfHeroesPlanner.Data.Mids.Tests
{
    public class PowerReaderTests
    {
        [Fact]
        public void CanReadPower()
        {
            using (var memoryStream = new MemoryStream())
            {
                var power = new Power
                {                    
                };
                using (var binaryWriter = new BinaryWriter(memoryStream, Encoding.Default, true))
                {
                 
                }

                memoryStream.Seek(0, SeekOrigin.Begin);

                using (var binaryReader = new BinaryReader(memoryStream, Encoding.Default, true))
                {
                    var powerReader = new PowerReader(binaryReader);
                    var record = powerReader.Read();
                    Assert.Equal(power, record);
                }
            }
        }
    }
}
