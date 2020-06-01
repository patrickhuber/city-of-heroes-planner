using CityOfInfo.Domain.EntityFramework;
using System;
using Xunit;

namespace CityOfInfo.Domain.Tests
{
    public class DomainContextTests
    {
        [Fact]
        public void SouldGetErrorForEnteringSamePowerIdTwice()
        {
            var powers = new Power[] 
            { 
                new Power{ Id = 0, Name = "test" },
                new Power { Id = 0, Name = "other" },
            };
            var domainContext = new DomainContext();
            Assert.Throws<Exception>(() => 
            {

            });
        }
    }
}
