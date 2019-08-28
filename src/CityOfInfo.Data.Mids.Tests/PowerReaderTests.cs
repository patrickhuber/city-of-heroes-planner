using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CityOfInfo.Data.Mids.Tests
{
    public class PowerReaderTests
    {
        [Fact]
        public void CanReadPower()
        {            
            var power = Fake.Create<Power>();
            new ReaderTest(
                setup: (writer) => 
                {
                    var powerWriter = new PowerWriter(writer);
                    powerWriter.Write(power);
                }, 
                test: (reader) => 
                {
                    var powerReader = new PowerReader(reader);
                    var record = powerReader.Read();
                    Assert.Equal(power, record);
                }).Run();            
        }
    }
}
