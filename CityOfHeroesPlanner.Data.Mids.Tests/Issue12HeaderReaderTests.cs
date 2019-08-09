using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CityOfHeroesPlanner.Data.Mids.Tests
{    
    public class Issue12HeaderReaderTests
    {
        [Fact]
        public void CanReadHeaderWithYearMonthDay()
        {
            var description = Issue12Header.MarkTwoVersionHeader;
            var version = (float)1234;
            var year = (int)2019;
            var month = (int)4;
            var day = (int)24;
            var issue = (int)25;

            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(memoryStream, Encoding.Default, true))
                {                    
                    writer.Write(description);                    
                    writer.Write(version);                    
                    writer.Write(year);                    
                    writer.Write(month);                    
                    writer.Write(day);                    
                    writer.Write(issue);
                }
                memoryStream.Seek(0, SeekOrigin.Begin);

                using (var reader = new BinaryReader(memoryStream, Encoding.Default, true))
                {
                    var headerReader = new Issue12HeaderReader(reader);
                    var header = headerReader.Read();
                    Assert.Equal(description, header.Description);
                    Assert.Equal(version, header.Version);
                    Assert.Equal(year, header.Date.Year);
                    Assert.Equal(month, header.Date.Month);
                    Assert.Equal(day, header.Date.Day);
                    Assert.Equal(issue, header.Issue);
                }                    
            }            
        }

        [Fact]
        public void CanReadHeaderWithDate()
        {
            var description = Issue12Header.MarkTwoVersionHeader;
            var version = (float)1234;
            var year = 0;
            var date = new DateTime(2019, 04, 24);
            var issue = (int)25;

            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(memoryStream, Encoding.Default, true))
                {
                    writer.Write(description);
                    writer.Write(version);
                    writer.Write(year);
                    writer.Write(date.ToBinary());
                    writer.Write(issue);
                }
                memoryStream.Seek(0, SeekOrigin.Begin);

                using (var reader = new BinaryReader(memoryStream, Encoding.Default, true))
                {
                    var headerReader = new Issue12HeaderReader(reader);
                    var header = headerReader.Read();
                    Assert.Equal(description, header.Description);
                    Assert.Equal(version, header.Version);                    
                    Assert.Equal(date, header.Date);                    
                    Assert.Equal(issue, header.Issue);
                }
            }
        }
    }
}
