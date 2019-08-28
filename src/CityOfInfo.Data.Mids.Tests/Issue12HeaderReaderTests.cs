using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CityOfInfo.Data.Mids.Tests
{    
    public class Issue12HeaderReaderTests
    {
        [Fact]
        public void CanReadHeaderWithYearMonthDay()
        {
            var issue12Header = Fake.Create<Issue12Header>();
            new ReaderTest(
                setup: (writer) => 
                {
                    writer.Write(issue12Header.Description);
                    writer.Write(issue12Header.Version);                    
                    writer.Write(issue12Header.Date.Year);
                    writer.Write(issue12Header.Date.Month);
                    writer.Write(issue12Header.Date.Day);
                    writer.Write(issue12Header.Issue);
                }, 
                test: (reader) => 
                {
                    var headerReader = new Issue12HeaderReader(reader);
                    var header = headerReader.Read();
                    Assert.Equal(issue12Header, header);
                }).Run();      
        }

        [Fact]
        public void CanReadHeaderWithDate()
        {            
            var issue12Header = Fake.Create<Issue12Header>();

            new ReaderTest(
                setup: (writer) =>
                {
                    new Issue12HeaderWriter(writer).Write(issue12Header);
                },
                test: (reader) =>
                {
                    var headerReader = new Issue12HeaderReader(reader);
                    var header = headerReader.Read();
                    Assert.Equal(issue12Header, header);
                }).Run();
        }
    }
}
