using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CityOfInfo.Data.Mids.Tests
{
    public class PowerSetReaderTests
    {
        [Fact]
        public void CanReadPowerset()
        {   
            var powerset = Fake.Create<PowerSet>();
            new ReaderTest(
                setup: (writer) => 
                {
                    new PowerSetWriter(writer).Write(powerset);
                }, 
                test: (reader) => 
                {

                    var powersetReader = new PowerSetReader(reader);
                    var record = powersetReader.Read();
                    Assert.Equal(powerset, record);
                }).Run();                
            
        }
    }
}
